import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginService } from './login.service';
import { Judoka } from '../data/judoka.data';
import { User } from '../data/user.data';

@Injectable()
export class PendingUserService extends LoginService {
    protected pendingUserUrl : string = environment.apiHost+"/PendingUser/";

    get(id: number) {
      return this.http.get(this.pendingUserUrl + id); 
    }
    getAll() {
      return this.http.get(this.pendingUserUrl); 
    }
    delete(id: number) {
      return this.http.delete(this.pendingUserUrl + id); 
    }   
    update(id: number, user: User) {
      return this.http.put(this.pendingUserUrl + id, user); 
    }  
}
