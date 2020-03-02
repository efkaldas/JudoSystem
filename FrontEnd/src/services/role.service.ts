import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RoleService {
  protected getRolesUrl : string = environment.apiHost+"/Role";
    
  constructor(protected http: HttpClient) {}

  getRoles() {
    return this.http.get(this.getRolesUrl); 
  }  
}
