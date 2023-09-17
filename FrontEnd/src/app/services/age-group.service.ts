import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginService } from './login.service';
import { AgeGroup } from '../data/age-group.data';

@Injectable()
export class AgeGroupService extends LoginService {
  protected ageGroupUrl : string = environment.apiHost+"/AgeGroup/";
  protected judokasToRegisterUrl : string = "/Judokas";
  protected weightCategoryUrl : string = "/WeightCategories/";
  protected coachUrl : string = "/Coach/";

  getAll() {
    return this.http.get(this.ageGroupUrl); 
  }  
  get(id: number) {
    return this.http.get(this.ageGroupUrl + id); 
  }
  getWeightCategories(id: number) {
    return this.http.get(this.ageGroupUrl + id + this.weightCategoryUrl); 
  }  
  getJudokasToRegister(groupId: number, coachId: number) {
    return this.http.get(this.ageGroupUrl + groupId + this.coachUrl + coachId + this.judokasToRegisterUrl); 
  } 
  update(id: number, ageGroup: AgeGroup) {
    return this.http.put(this.ageGroupUrl + id, ageGroup); 
  } 
  create(ageGroup: AgeGroup) {
    return this.http.post(this.ageGroupUrl, ageGroup); 
  } 
  delete(id: number) {
    return this.http.delete(this.ageGroupUrl + id); 
  } 
}