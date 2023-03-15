import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginService } from './login.service';


@Injectable()
export class UserService extends LoginService{
  protected userUrl : string = environment.apiHost+"/User/";  
  protected userFullUrl : string = environment.apiHost+"/User/full/"; 
  protected registerUserUrl : string = environment.apiHost+"/Registration";  
  protected uploadAvatarUrl : string = "/UploadAvatar";  

  get(id: number) {
    return this.http.get(this.userUrl + id);
  }  
  getFull(id: number) {
    return this.http.get(this.userFullUrl + id);
  }
  getAll() {
    return this.http.get(this.userFullUrl);
  }  
  updateProfile(user: User) {
    return this.http.put(this.userFullUrl, user);
  }   

  registerUser(user: User, organization: Organization) {
    user.organization = organization;
    return this.http.post(this.registerUserUrl, user); 
  }

  public uploadAvatar(file) {
    const formData = new FormData();
    formData.append('file', file, file.name); 

    let headers = new HttpHeaders(); 
    headers.append('Accept','image');
    
    return this.http.post(this.userUrl + this.uploadAvatarUrl, formData, {headers: headers, responseType: 'blob' }).toPromise();  
  }
}
