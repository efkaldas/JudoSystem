import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Login } from '../data/login.model';

@Injectable()
export class LoginApiService {

    constructor(public http: HttpClient) { }

    public LoginUrl : string = environment.apiHost+"/auth/";

    public Login(login : Login){
        return this.http.post(this.LoginUrl, login);
    }
    public getToken() : string {
        let result = localStorage.getItem('jwtToken');
        if (result == 'undefined')
            return null;
        return result;
   }
   
   public setToken(token : string) : void {
        localStorage.setItem('jwtToken', token);
   }

   isLoggedIn() : boolean {
        return (this.getToken() != null);
   }

   logout() {
    localStorage.removeItem('jwtToken');
   }
}