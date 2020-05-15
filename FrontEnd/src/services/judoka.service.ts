import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { LoginService } from './Login.service';
import { Judoka } from '../data/judoka.data';

@Injectable()
export class JudokaService extends LoginService {
    protected judokaUrl : string = environment.apiHost+"/Judoka/";
    protected myJudokasUrl : string = "MyJudokas";
    protected byRankUrl : string = "ByRank";

    get(id: number) {
      return this.http.get(this.judokaUrl + id); 
    }
    getAll() {
      return this.http.get(this.judokaUrl); 
    }
    getMyJudokas() {
        return this.http.get(this.judokaUrl + this.myJudokasUrl); 
    }
    getByRank(id: number) {
      return this.http.get(this.judokaUrl + this.byRankUrl, {params: { genderId: id.toString() }}) ; 
    }
    delete(id: number) {
      return this.http.delete(this.judokaUrl + id); 
    } 
    create(judoka: Judoka) {
      return this.http.post(this.judokaUrl, judoka); 
    }   
    update(id: number, judoka: Judoka) {
      return this.http.put(this.judokaUrl + id, judoka); 
    }  
}
