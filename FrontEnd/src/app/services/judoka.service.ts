import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../data/users.model';
import { Judoka } from '../data/judoka.model';
import { LoginApiService } from './login.service';

@Injectable()
export class JudokaApiService extends LoginApiService{

    public judokasUrl : string = environment.apiHost+"/Judoka/";
    public userJudokasUrl : string = environment.apiHost+"/Judoka/UserJudokas/";

    public getJudokas(){
        return this.http.get(this.judokasUrl);
    }
    
    public getUserJudokas(){
        return this.http.get(this.userJudokasUrl);
    }
    public createJudoka(judoka: Judoka){
        const headers = new HttpHeaders().set('content-type', 'application/json');
        var body = {  
            FirstName:judoka.FirstName,
            LastName:judoka.LastName,
            Gender:judoka.Gender,
            DanKyu:judoka.DanKyu,
            BirthYears:judoka.BirthYears
     } 
        console.log(judoka);
        return this.http.post<Judoka>(this.judokasUrl, body, { headers });
    }
    public removeJudoka(id: number)
    {        
        return this.http.delete(this.judokasUrl + id);
    }
}