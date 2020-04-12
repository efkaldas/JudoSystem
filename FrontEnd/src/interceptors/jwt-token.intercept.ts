import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import { LoginService } from '../services/Login.service';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {
    
    constructor(private authService: LoginService) {  }


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let jwtToken =  this.authService.getToken();
        const JWT = 'Bearer ' + jwtToken;
        req = req.clone({
            headers: req.headers.set('Authorization', JWT)
        });
        
        return next.handle(req);
    }
}