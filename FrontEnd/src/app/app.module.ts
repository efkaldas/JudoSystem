import * as $ from 'jquery';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { AppBreadcrumbComponent } from './layouts/full/breadcrumb/breadcrumb.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { SharedModule } from './shared/shared.module';
import { SpinnerComponent } from './shared/spinner.component';
import { OrganizationTypeService } from '../services/organization-type.service';
import { UserService } from '../services/user.service';
import { RoleService } from '../services/role.service';
import { GenderService } from '../services/gender.service';
import { LoginService } from '../services/Login.service';
import { MyJudokasComponent } from './components/my-judokas/my-judokas.component';
import { JudokaService } from '../services/judoka.service';
import { httpInterceptorProviders } from '../interceptors/interceptor-provider';
import { DanKyuService } from '../services/dan-kyu.service';
import { CoachComponent } from './components/coach/coach.component';
import { PendingUsersComponent } from './components/pending-users/pending-users.component';
import { PendingUserService } from '../services/pending-user.service';
import { WaitingForApprovementComponent } from './authentication/error/waiting-for-approvement/waiting-for-approvement.component';
import { HomeComponent } from './components/home/home.component';
import { CompetitionsComponent } from './components/Competitons/competitions/competitions.component';
import { CoachService } from '../services/coach.service';
import { CoachShowComponent } from './components/coach-show/coach-show.component';
import { CoachOrganizationComponent } from './components/coach-show/coach-organization/coach-organization.component';
import { CoachProfileComponent } from './components/coach-show/coach-profile/coach-profile.component';
import { CompetitionsService } from '../services/Competitions.service';
import { NewCompetitionsComponent } from './components/Competitons/new-competitions/new-competitions.component';
import { QuillModule } from 'ngx-quill';
import { CompetitionsTypeService } from '../services/competitions-type.service';
import { NewAgeGroupComponent } from './components/new-age-group/new-age-group.component';
import { CompetitionsShowComponent } from './components/Competitons/competitions-show/competitions-show.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AgeGroupService } from '../services/age-group.service';
import { WeightCategoryService } from '../services/weight-category.service';
import { UserCoachesComponent } from './components/user-coaches/user-coaches.component';
import { OrganizationsComponent } from './components/organizations/organizations.component';
import { OrganizationService } from '../services/organization.service';
import { CompetitionsMyCompetitorsComponent } from './components/Competitons/competitions-my-competitors/competitions-my-competitors.component';
import { JudokaProfileComponent } from './components/judoka-profile/judoka-profile.component';
import { JudokasRatingComponent } from './components/judokas-rating/judokas-rating.component';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelSpeed: 2,
  wheelPropagation: true
};

@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppBlankComponent,
    AppSidebarComponent,
	AppBreadcrumbComponent,
	MyJudokasComponent,
	CoachComponent,
	PendingUsersComponent,
	HomeComponent,
	CompetitionsComponent,
	CoachShowComponent,
	CoachOrganizationComponent,
	CoachProfileComponent,
	NewCompetitionsComponent,
	NewAgeGroupComponent,
	CompetitionsShowComponent,
	ProfileComponent,
	UserCoachesComponent,
	OrganizationsComponent,
	CompetitionsMyCompetitorsComponent,
	JudokaProfileComponent,
	JudokasRatingComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    FormsModule,
    FlexLayoutModule,
    HttpClientModule,
    PerfectScrollbarModule,
    SharedModule,
    QuillModule.forRoot(),
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot(),
    RouterModule.forRoot(AppRoutes),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: httpTranslateLoader,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
    httpInterceptorProviders,
    OrganizationTypeService,
    UserService,
    RoleService,
    GenderService,
    LoginService,
    JudokaService,
    DanKyuService,
    PendingUserService,
    CoachService,
    CompetitionsService,
    CompetitionsTypeService,
    AgeGroupService,
    WeightCategoryService,
    OrganizationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

// AOT compilation support
export function httpTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
