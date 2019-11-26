import {Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from '../data/users.model';

@Injectable()
export class UsersApiService {

    constructor(private http: HttpClient) { }

    public UsersListUrl : string = environment.apiHost+"/user";

    public getUsers(){
        return this.http.get(this.UsersListUrl);
    }
}