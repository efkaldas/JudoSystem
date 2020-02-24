import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class OrganizationTypeService {
  protected getOrganizationTypesUrl : string = environment.apiHost+"/OrganizationType";  


  constructor(protected http: HttpClient) {}


  getOrganizationTypes() {
    console.log(this.getOrganizationTypesUrl);
    return this.http.get(this.getOrganizationTypesUrl); 
  }  
}
