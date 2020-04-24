import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';
import { User } from '../data/user.data';

@Injectable()
export class CoachService extends LoginService {
  protected coachUrl : string = environment.apiHost+"/Coach/";

  getAll() {
    return this.http.get(this.coachUrl); 
  }  
  get(id: number) {
    return this.http.get(this.coachUrl + id); 
  } 
  update(id: number, coach: User) {
    return this.http.put(this.coachUrl + id, coach); 
  } 
  create(coach: User) {
    return this.http.post(this.coachUrl, coach); 
  } 
}