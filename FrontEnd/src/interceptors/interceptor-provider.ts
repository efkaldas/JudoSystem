import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { JwtTokenInterceptor } from './jwt-token.intercept';

/** Http interceptor providers in outside-in order */
export const httpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptor, multi: true },
  ];