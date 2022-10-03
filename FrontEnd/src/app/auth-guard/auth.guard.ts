import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../services/Login.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private apiService: LoginService, private router: Router) { }

  loggedInUser: any;

  canActivate(route: ActivatedRouteSnapshot) {
    if (this.apiService.isLoggedIn()) {
        this.loggedInUser = this.apiService.getParsedJwtToken();

        const currentUser = this.apiService.currentUserValue;

        if(this.loggedInUser != null)  
        {
            if (this.loggedInUser['http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor']  === "Blocked") {
                // role not authorised so redirect to home page
                this.router.navigate(['/user-blocked']);
                this.apiService.logout();
                return false;
            }
            else if (this.loggedInUser['http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor'] === "Not аpproved") {
                // role not authorised so redirect to home page
                this.router.navigate(['/not-approved']);
                this.apiService.logout();
                return false;
            }
            if (route.data.roles && !route.data.roles.some( x => (this.loggedInUser['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']).indexOf(x) !== -1)) {
                // role not authorised so redirect to home page
                this.router.navigate(['/login']);
                return false;
            }          
            // authorised so return true
            return true;
        }
        return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/login']);
    return false;
    
}
}
