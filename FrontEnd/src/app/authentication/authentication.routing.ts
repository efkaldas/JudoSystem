import { Routes } from '@angular/router';

import { ErrorComponent } from './error/error.component';
import { ForgotComponent } from './forgot/forgot.component';
import { LockscreenComponent } from './lockscreen/lockscreen.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PermissionDeniedComponent } from './error/permission-denied/permission-denied.component';
import { NotApprovedComponent } from './error/not-approved/not-approved.component';
import { LogoutComponent } from './logout/logout.component';
import { WaitingForApprovementComponent } from './error/waiting-for-approvement/waiting-for-approvement.component';
import { UserBlockedComponent } from './error/user-blocked/user-blocked.component';
export const AuthenticationRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '404',
        component: ErrorComponent
      },
      {
        path: 'waiting-for-approvement',
        component: WaitingForApprovementComponent
      },
      {
        path: 'not-approved',
        component: NotApprovedComponent
      },
      {
        path: 'permission-denied',
        component: PermissionDeniedComponent
      },
      {
        path: 'user-blocked',
        component: UserBlockedComponent
      },
      {
        path: 'forgot',
        component: ForgotComponent
      },
      {
        path: 'lockscreen',
        component: LockscreenComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'logout',
        component: LogoutComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      }
    ]
  }
];
