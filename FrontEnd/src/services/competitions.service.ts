import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './Login.service';
import { Competitions } from '../data/competitions.data';

@Injectable()
export class CompetitionsService extends LoginService {
  protected competitionsUrl : string = environment.apiHost+"/Competitions/";
  protected ageGroupUrl : string = "/AgeGroup";

  getAll() {
    return this.http.get(this.competitionsUrl); 
  }  
  get(id: number) {
    return this.http.get(this.competitionsUrl + id); 
  } 

  getAgeGroups(id: number) {
    return this.http.get(this.competitionsUrl + id + this.ageGroupUrl); 
  } 
  update(id: number, coach: Competitions) {
    return this.http.put(this.competitionsUrl + id, coach); 
  } 
  create(coach: Competitions) {
    return this.http.post(this.competitionsUrl, coach); 
  } 
}