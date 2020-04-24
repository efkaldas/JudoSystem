import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';
import { Competitions } from '../data/competitions.data';

@Injectable()
export class CompetitionsTypeService extends LoginService {
  protected competitionsTypeUrl : string = environment.apiHost+"/CompetitionsType/";

  getAll() {
    return this.http.get(this.competitionsTypeUrl); 
  }  
}