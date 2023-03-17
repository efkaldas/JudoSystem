import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginService } from './login.service';
import { Judoka } from '../data/judoka.data';
import { User } from '../data/user.data';
import { Organization } from '../data/organization.data';
import { HttpHeaders } from '@angular/common/http';

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

    public uploadImage(file) {
      const formData = new FormData();
      formData.append('image', file, file.name); 
  
      console.log(formData.getAll);
      
      return this.http.post(this.organizationUrl + this.uploadImageUrl, formData);  
    }
}
