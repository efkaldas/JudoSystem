import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';

@Injectable()
export class OrganizationTypeService extends LoginService {
  protected getOrganizationTypesUrl : string = environment.apiHost+"/OrganizationType";  

  getAll() {
    console.log(this.getOrganizationTypesUrl);
    return this.http.get(this.getOrganizationTypesUrl); 
  }  
}
