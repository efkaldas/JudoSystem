import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Login } from '../data/login.model';
import { LoginApiService } from './login.service';
import { UserDao } from '../data/userDao.model';

@Injectable()
export class RegistrationApiService extends LoginApiService {

    public RegistrationUrl : string = environment.apiHost+"/Registration";

    public Register(newUser: UserDao){
        return this.http.post(this.RegistrationUrl, newUser);
    }

}