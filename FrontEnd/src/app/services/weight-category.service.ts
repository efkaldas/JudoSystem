import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginService } from './Login.service';
import { Judoka } from '../data/judoka.data';


@Injectable()
export class WeightCategoryService extends LoginService{
  protected weightCategoryUrl : string = environment.apiHost+"/WeightCategory/";  
  protected competitorUrl : string = "/Competitors"; 
  protected resultsUrl : string = "/Results"; 

  registerCompetitor(id: number, judoka: Judoka) {
    return this.http.post(this.weightCategoryUrl + id + this.competitorUrl, judoka);
  } 
  deleteCompetitor(id: number, judoka: Judoka) {
    return this.http.put(this.weightCategoryUrl + id + this.competitorUrl, judoka);
  }
  getCompetitors(id: number) {
    return this.http.get(this.weightCategoryUrl + id + this.competitorUrl);
  }  
  getResults(id: number) {
    return this.http.get(this.weightCategoryUrl + id + this.resultsUrl);
  }  
}
