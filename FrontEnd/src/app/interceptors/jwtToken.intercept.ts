import { Observable } from 'rxjs';
import { LoginApiService } from '../services/login.service';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {
    
    constructor(private authService: LoginApiService) {  }


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let jwtToken =  this.authService.getToken();
        const JWT = 'Bearer ' + jwtToken;
        req = req.clone({
            headers: req.headers.set('Authorization', JWT)
        });
        
        return next.handle(req);
    }
}