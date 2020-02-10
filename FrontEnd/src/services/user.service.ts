import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class UserService {
  protected getAdminUsersUrl : string = environment.apiHost+"/AdminUser/GetAdminUsers";  
  protected registerUserUrl : string = environment.apiHost+"/Registration";  


  constructor(protected http: HttpClient) {}

  getUsers() {
    return this.http.get(this.getAdminUsersUrl); 
  }  
  registerUser(user: User, organization: Organization) {
    user.organization = organization;
    console.log(user);
    return this.http.post(this.registerUserUrl, user); 
  }
}
