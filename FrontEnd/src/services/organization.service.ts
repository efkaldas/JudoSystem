import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { LoginService } from './Login.service';
import { Judoka } from '../data/judoka.data';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';

@Injectable()
export class OrganizationService extends LoginService {
    protected organizationUrl : string = environment.apiHost+"/Organization/";

    getAll() {
      return this.http.get(this.organizationUrl); 
    }
    update(id: number, organization: Organization) {
      return this.http.put(this.organizationUrl + id, organization); 
    }  
}
