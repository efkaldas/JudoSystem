import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';

@Injectable()
export class RoleService extends LoginService {
  protected getRolesUrl : string = environment.apiHost+"/Role";

  getAll() {
    return this.http.get(this.getRolesUrl); 
  }  
}
