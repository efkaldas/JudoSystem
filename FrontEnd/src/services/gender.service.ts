import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';

@Injectable()
export class GenderService extends LoginService {
  protected getGenderUrl : string = environment.apiHost+"/Gender";

  getAll() {
    return this.http.get(this.getGenderUrl); 
  }  
}
