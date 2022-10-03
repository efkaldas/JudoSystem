import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';

@Injectable()
export class DanKyuService extends LoginService {
  protected danKyuUrl : string = environment.apiHost+"/DanKyu";

  getAll() {
    return this.http.get(this.danKyuUrl); 
  }  
}