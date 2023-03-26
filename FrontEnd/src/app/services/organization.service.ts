import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginService } from './login.service';
import { Judoka } from '../data/judoka.data';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class OrganizationService extends LoginService {
    protected organizationUrl : string = environment.apiHost+"/Organization/";
    protected uploadImageUrl : string = "UploadImage";

    getAll() {
      return this.http.get(this.organizationUrl); 
    }

    update(id: number, organization: Organization) {
      return this.http.put(this.organizationUrl + id, organization); 
    }  

    public uploadImage(file) : Observable<any>{
      const formData = new FormData();
      formData.append('image', file, file.name); 

      return this.http.post(this.organizationUrl + this.uploadImageUrl, formData).pipe(
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
