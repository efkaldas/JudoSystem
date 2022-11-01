import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './login.service';
import { User } from '../data/user.data';

@Injectable()
export class CoachService extends LoginService {
  protected coachUrl : string = environment.apiHost+"/Coach/";
  protected blockhUrl : string = "/Block/";
  protected unBlockUrl : string = "/UnBlock/";
  protected myUrl : string = "My/";

  getAll() {
    return this.http.get(this.coachUrl); 
  }  
  getMy() {
    return this.http.get(this.coachUrl + this.myUrl); 
  } 
  get(id: number) {
    return this.http.get(this.coachUrl + id); 
  } 
  update(id: number, coach: User) {
    return this.http.put(this.coachUrl + id, coach); 
  } 
  block(id: number) {
    return this.http.put(this.coachUrl + id + this.blockhUrl, null); 
  } 
  unBlock(id: number) {
    return this.http.put(this.coachUrl + id + this.unBlockUrl, null); 
  } 
  create(coach: User) {
    return this.http.post(this.coachUrl, coach); 
  } 
}