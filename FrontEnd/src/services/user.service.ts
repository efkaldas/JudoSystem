import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';


@Injectable()
export class UserService {
  protected getAdminUsersUrl : string = environment.apiHost+"/AdminUser/GetAdminUsers";  
  http: any;

  getAdminUsers() {
    return this.http.get(this.getAdminUsersUrl); 
}  
}
