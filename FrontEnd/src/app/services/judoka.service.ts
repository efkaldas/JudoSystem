import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from '../data/users.model';
import { Judoka } from '../data/judoka.model';
import { LoginApiService } from './login.service';

@Injectable()
export class JudokaApiService extends LoginApiService{

    public judokasUrl : string = environment.apiHost+"/Judoka/";

    public getJudokas(){
        return this.http.get(this.judokasUrl);
    }
    public createJudoka(judoka: Judoka){
        return this.http.post(this.judokasUrl, judoka);
    }
    public removeJudoka(judoka: Judoka)
    {
        return this.http.post(this.judokasUrl + judoka.id, judoka);
    }
}