import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import {
  MatIconModule,
  MatCardModule,
  MatInputModule,
  MatCheckboxModule,
  MatButtonModule,
  MatStepperModule
} from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AuthenticationRoutes } from './authentication.routing';
import { ErrorComponent } from './error/error.component';
import { ForgotComponent } from './forgot/forgot.component';
import { LockscreenComponent } from './lockscreen/lockscreen.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DemoMaterialModule } from '../demo-material-module';
import { OrganizationTypeService } from '../../services/organization-type.service';
import { UserService } from '../../services/user.service';
import { RoleService } from '../../services/role.service';
import { GenderService } from '../../services/gender.service';
import { LoginService } from '../../services/Login.service';
import { NotApprovedComponent } from './error/not-approved/not-approved.component';
import { PermissionDeniedComponent } from './error/permission-denied/permission-denied.component';
import { LogoutComponent } from './logout/logout.component';
import { WaitingForApprovementComponent } from './error/waiting-for-approvement/waiting-for-approvement.component';
import { UserBlockedComponent } from './error/user-blocked/user-blocked.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AuthenticationRoutes),
    DemoMaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MatStepperModule
  ],
  providers: [
    OrganizationTypeService,
    UserService,
    RoleService,
    GenderService,
    LoginService
  ],
  declarations: [
    ErrorComponent,
    ForgotComponent,
    LockscreenComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent,
    PermissionDeniedComponent,
    NotApprovedComponent,
    WaitingForApprovementComponent,
    UserBlockedComponent
  ]
})
export class AuthenticationModule {}
