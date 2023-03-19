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

@Injectable()
export class LoginService {
  protected authUrl: string = environment.apiHost + "/Authentication"
  protected loginUrl: string = this.authUrl + "/Login";
  protected forgotPasswordUrl: string = this.authUrl + "/ForgotPassword";
  protected resetPasswordUrl: string = this.authUrl + "/ResetPassword";

  constructor(protected http: HttpClient) {}

  private currentUserSubject: BehaviorSubject<LoggedInUser>;
  public currentUser: Observable<LoggedInUser>;
  private logger = new Subject<boolean>();
  private user = new Subject();
  private loggedIn = false;


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
    localStorage.setItem('user', JSON.stringify(user));
    console.log(user);
    this.user.next(user);
    console.log(this.user.asObservable());
  }

  public getUser(): User {
    let result = JSON.parse(localStorage.getItem('user')) as User;
    if (result == null) return null;
    return result;
  }

  public getUserV2(): Observable<any> {
    console.log(this.user.asObservable());
    return this.user.asObservable();
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
    this.logger.next(this.loggedIn);
  }
}
