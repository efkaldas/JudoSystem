import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Login } from "../data/login.data";
import { LoggedInUser } from "../data/LoggedInUser.data";
import { BehaviorSubject, Observable } from "rxjs";
import * as jwt_decode from "jwt-decode";
import { User } from "../data/user.data";

@Injectable()
export class LoginService {
  protected loginUrl: string = environment.apiHost + "/Login";

  constructor(protected http: HttpClient) {}

  private currentUserSubject: BehaviorSubject<LoggedInUser>;
  public currentUser: Observable<LoggedInUser>;


  login(login: Login) {
    return this.http.post(this.loginUrl, login);
  }

  public getToken(): string {
    let result = localStorage.getItem("jwtToken");
    if (result == "undefined") return null;
    return result;
  }

  public setToken(token: string): void {
    localStorage.setItem("jwtToken", token);
  }

  public setUser(user: User): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  public getUser(): User {
    let result = JSON.parse(localStorage.getItem('user')) as User;
    if (result == null) return null;
    return result;
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
  }
}
