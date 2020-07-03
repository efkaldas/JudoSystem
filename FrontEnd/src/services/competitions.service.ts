import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginService } from './Login.service';
import { Competitions } from '../data/competitions.data';

@Injectable()
export class CompetitionsService extends LoginService {
  protected competitionsUrl : string = environment.apiHost+"/Competitions/";
  protected ageGroupUrl : string = "/AgeGroups";
  protected printCompetitorsUrl : string = "/Competitors-list.csv";
  protected importResultsUrl : string = "/ResultsFile"; 
  protected myCompetitorsUrl : string = "/MyCompetitors"; 

  getAll() {
    return this.http.get(this.competitionsUrl); 
  }  
  get(id: number) {
    return this.http.get(this.competitionsUrl + id); 
  } 

  getAgeGroups(id: number) {
    return this.http.get(this.competitionsUrl + id + this.ageGroupUrl); 
  } 
  update(id: number, competitions: Competitions) {
    return this.http.put(this.competitionsUrl + id, competitions); 
  } 
  delete(id: number) {
    return this.http.delete(this.competitionsUrl + id); 
  } 
  create(competitions: Competitions) {
    return this.http.post(this.competitionsUrl, competitions); 
  }
  getMyCompetitors(id:number) {
    return this.http.get(this.competitionsUrl + id + this.myCompetitorsUrl); 
  }

  print(id: number) {
    let headers = new HttpHeaders(); 
    headers.append('Accept','text/csv;charset=utf-8');

    return this.http.get(this.competitionsUrl + id  + this.printCompetitorsUrl, {headers: headers, responseType: 'blob' }); 
  }  
  public importResultsFile(file, id : number) {
    const formData = new FormData();
    formData.append('file', file, file.name);    

    let headers = new HttpHeaders(); 
    headers.append('Accept','text/pdf');
    
    return this.http.post(this.competitionsUrl + id + this.importResultsUrl, formData, {headers: headers, responseType: 'blob' });  
  } 
}