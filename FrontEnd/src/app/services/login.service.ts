import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Login } from "../data/login.data";
import { LoggedInUser } from "../data/LoggedInUser.data";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import * as jwt_decode from "jwt-decode";
import { User } from "../data/user.data";
import { ForgotPassword } from "../data/forgotPassword.data";
import { ResetPassword } from "../data/resetPassword.data";
import { Organization } from "../data/organization.data";

@Injectable()
export class LoginService {
  protected authUrl: string = environment.apiHost + "/Authentication"
  protected loginUrl: string = this.authUrl + "/Login";
  protected forgotPasswordUrl: string = this.authUrl + "/ForgotPassword";
  protected resetPasswordUrl: string = this.authUrl + "/ResetPassword";

  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  private currentUserSubject: BehaviorSubject<LoggedInUser>;
  public currentUser: Observable<LoggedInUser>;
  private logger = new Subject<boolean>();
  private loggedIn = false;

  constructor(protected http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('user'))
    );
    this.user = this.userSubject.asObservable();
  }

  login(login: Login) {
    return this.http.post(this.loginUrl, login);
  }

  forgotPassword(forgotPassword: ForgotPassword) {
    return this.http.post(this.forgotPasswordUrl, forgotPassword);
  }

   resetPassword(resetPassword: ResetPassword) {
    return this.http.post(this.resetPasswordUrl, resetPassword);
  }

  public getToken(): string {
    let result = localStorage.getItem("jwtToken");
    if (result == "undefined") return null;
    return result;
  }

  logIn(provider: string, providerResponse: string) {
    localStorage.setItem('authParams', providerResponse);
    this.loggedIn = true;
    this.logger.next(this.loggedIn);
  }

  isUserLoggedIn(): Observable<boolean> {
    return this.logger.asObservable();
  }

  public setToken(token: string): void {
    localStorage.setItem("jwtToken", token);
    this.loggedIn = true;
  }

  public setUser(user: User): void {
    user.image = user.image ? "data:image/png;base64," + user.image : "assets/images/users/no_user_image.png";
    user.organization.image = user.organization.image ? "data:image/png;base64," + user.organization.image : "assets/images/organizations/no_image.png";
    localStorage.setItem('user', JSON.stringify(user));
    this.userSubject.next(user);
  }

  public setOrganization(organization: Organization): void {
    organization.image = organization.image ? "data:image/png;base64," + organization.image : "assets/images/organizations/no_image.png";
    this.userSubject.value.organization = organization;
    localStorage.setItem('user', JSON.stringify(this.userSubject.value));
    this.userSubject.next(this.userSubject.value);
  }

  public getUser(): User {
    return this.userSubject.value;
  }

  isLoggedIn(): boolean {
    return this.getToken() != null;
  }

  public get currentUserValue(): LoggedInUser {
    this.currentUserSubject = new BehaviorSubject<LoggedInUser>(this.getDecodedAccessToken(localStorage.getItem('jwtToken')));
    this.currentUser = this.currentUserSubject.asObservable();
    return this.currentUserSubject.value;
  }

    public getDecodedAccessToken(token: string): any {
         try{
              return jwt_decode(token);
         }
         catch(Error){
              return null;
         }
    }

  public getParsedJwtToken() : any {
       return this.getDecodedAccessToken(localStorage.getItem('jwtToken'));
  }

  public logout() {
    localStorage.removeItem("jwtToken");
    localStorage.removeItem("user");
    this.loggedIn = false;
    this.userSubject.next(null);
  }
}
