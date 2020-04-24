import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';


@Injectable()
export class UserService extends LoginService{
  protected userUrl : string = environment.apiHost+"/User/";  
  protected userFullUrl : string = environment.apiHost+"/User/full/"; 
  protected registerUserUrl : string = environment.apiHost+"/Registration";  

  get(id: number) {
    console.log(id);
    return this.http.get(this.userUrl + id);
  }  
  getFull(id: number) {
    console.log(id);
    return this.http.get(this.userFullUrl + id);
  } 
  updateProfile(user: User) {
    return this.http.put(this.userFullUrl, user);
  }   

  registerUser(user: User, organization: Organization) {
    user.organization = organization;
    return this.http.post(this.registerUserUrl, user); 
  }
}
