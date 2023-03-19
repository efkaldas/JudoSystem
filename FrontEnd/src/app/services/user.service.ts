import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { LoginService } from './login.service';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';


@Injectable()
export class UserService extends LoginService{
  protected userUrl : string = environment.apiHost+"/User/";  
  protected userFullUrl : string = environment.apiHost+"/User/full/"; 
  protected registerUserUrl : string = environment.apiHost+"/Registration";  
  protected uploadProfileImageUrl : string = "UploadProfileImage";  

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

 uploadProfileImage(file) : Observable<any>  {
    const formData = new FormData();
    formData.append('image', file, file.name); 

    console.log(formData.getAll);
    
    return this.http.post(this.userUrl + this.uploadProfileImageUrl, formData).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError));  
  }

  private handleError(err: HttpErrorResponse) {

    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {

        errorMessage = `An error occurred: ${err.error.message}`;
    } else {

        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
