import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { MyJudokasComponent } from './components/my-judokas/my-judokas.component';
import { AuthGuard } from './auth-guard/auth.guard';
import { PendingUsersComponent } from './components/pending-users/pending-users.component';
import { HomeComponent } from './components/home/home.component';
import { Role } from '../data/user-role.enum.data';
import { CoachComponent } from './components/coach/coach.component';
import { CoachShowComponent } from './components/coach-show/coach-show.component';
import { ProfileComponent } from './components/profile/profile.component';
import { UserCoachesComponent } from './components/user-coaches/user-coaches.component';
import { OrganizationsComponent } from './components/organizations/organizations.component';
import { NewCompetitionsComponent } from './components/Competitons/new-competitions/new-competitions.component';
import { CompetitionsShowComponent } from './components/Competitons/competitions-show/competitions-show.component';
import { CompetitionsComponent } from './components/Competitons/competitions/competitions.component';
import { JudokaProfileComponent } from './components/judoka-profile/judoka-profile.component';
import { JudokasRatingComponent } from './components/judokas-rating/judokas-rating.component';
import { MyContestantsExportComponent } from './components/Competitons/competitions-show/my-contestants-export/my-contestants-export.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './authentication/register/register.component';
import { LoginComponent } from './authentication/login/login.component';
import { LogoutComponent } from './authentication/logout/logout.component';
import { ForgotComponent } from './authentication/forgot/forgot.component';
import { ErrorComponent } from './authentication/error/error.component';
import { WaitingForApprovementComponent } from './authentication/error/waiting-for-approvement/waiting-for-approvement.component';
import { NotApprovedComponent } from './authentication/error/not-approved/not-approved.component';
import { PermissionDeniedComponent } from './authentication/error/permission-denied/permission-denied.component';
import { LockscreenComponent } from './authentication/lockscreen/lockscreen.component';
import { UserBlockedComponent } from './authentication/error/user-blocked/user-blocked.component';
import { CompetitionsTabsComponent } from './components/Competitons/competitions-show/competitions-tabs/competitions-tabs.component';
import { CompetitionsInfoComponent } from './components/Competitons/competitions-show/competitions-info/competitions-info.component';
import { CompetitionsMyCompetitorsComponent } from './components/Competitons/competitions-show/competitions-my-competitors/competitions-my-competitors.component';
import { CompetitionsAgeGroupsComponent } from './components/Competitons/competitions-show/competitions-age-groups/competitions-age-groups.component';
import { CompetitionsCompetitorsComponent } from './components/Competitons/competitions-show/competitions-competitors/competitions-competitors.component';
import { CompetitionsResultsComponent } from './components/Competitons/competitions-show/competitions-results/competitions-results.component';
import { CompetitionsResultsWeightCategoriesComponent } from './components/Competitons/competitions-show/competitions-results/competitions-results-weight-categories/competitions-results-weight-categories.component';
import { CompetitionsResultsWeightCategoryShowComponent } from './components/Competitons/competitions-show/competitions-results/competitions-results-weight-category-show/competitions-results-weight-category-show.component';
import { TranslateModule } from '@ngx-translate/core';

export const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', redirectTo: '/home', pathMatch: 'full', data: {title: 'Home'} },
      { path: 'home', component: HomeComponent, data: {title: 'Home'} },
      { path: 'myjudokas', component: MyJudokasComponent, canActivate: [AuthGuard], data: {title: 'MyJudokas', roles: [Role.Admin, Role.Coach]} },
      { path: 'my-coaches', component: CoachComponent,canActivate: [AuthGuard], data: {title: 'Coaches', roles: [Role.Admin, Role.Organization_Admin]} },
      { path: 'users', component: UserCoachesComponent,canActivate: [AuthGuard], data: {title: 'Coaches', roles: [Role.Admin]} },
      { path: 'coaches/:id', component: CoachShowComponent, canActivate: [AuthGuard], data: {title: 'Coach'} },
      { path: 'pending-users', component: PendingUsersComponent, canActivate: [AuthGuard], data: {title: 'Pending Users', roles: [Role.Admin]} },
      { path: 'competitions', component: CompetitionsComponent, data: {title: 'Competitions'} },
      { path: 'competitions/:id', component: CompetitionsTabsComponent, data: {title: 'Competitions'}, 
        children: [
          { path: 'info', component: CompetitionsInfoComponent, data: {title: 'Competitions Information'} },
          { path: 'my-competitors', component: CompetitionsMyCompetitorsComponent, data: {title: 'Competitions My Competitiors'} },
          { path: 'age-groups', component: CompetitionsAgeGroupsComponent, data: {title: 'Competitions Age Groups'} },
          { path: 'competitors', component: CompetitionsCompetitorsComponent, data: {title: 'Competitors'} },
          { path: 'results', component: CompetitionsResultsComponent, data: {title: 'Competitions Results'},
            children: [
              { path: 'group/:groupId', component: CompetitionsResultsWeightCategoriesComponent, data: {title: 'Competitions Age Groups'},
                children: [
                  { path: 'weight-category/:categoryId', component: CompetitionsResultsWeightCategoryShowComponent, data: {title: 'Competitions Age Groups'} }
                ] }
              ] },
          ]},
      { path: 'competitions/:id/competitors-export', component: MyContestantsExportComponent, data: {title: 'Export'} },
      { path: 'new-competitions', component: NewCompetitionsComponent, canActivate: [AuthGuard], data: {title: 'Create Competitons', roles: [Role.Admin]} },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard], data: {title: 'Profile'} },
      { path: 'judoka/:id', component: JudokaProfileComponent, canActivate: [AuthGuard], data: {title: 'Judoka'} },
      { path: 'judokas/rating', component: JudokasRatingComponent, canActivate: [AuthGuard], data: {title: 'Judokas Rating'} },
      { path: 'organizations', component: OrganizationsComponent, canActivate: [AuthGuard], data: {title: 'Organizations', roles: [Role.Admin, Role.Organization_Admin]} },
      { path: 'forgot', component: ForgotComponent, canActivate: [AuthGuard], data: {title: 'Forgot'} },
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgot', component: ForgotComponent },
  { path: 'logout', component: LogoutComponent },
  { path: '404', component: ErrorComponent },
  { path: 'waiting-for-approvement', component: WaitingForApprovementComponent },
  { path: 'not-approved', component: NotApprovedComponent },
  { path: 'permission-denied', component: PermissionDeniedComponent },
  { path: 'user-blocked', component: UserBlockedComponent },
  { path: 'lockscreen', component: LockscreenComponent }
];
@NgModule({
  imports: [ RouterModule.forRoot(routes), TranslateModule ],
  exports: [ RouterModule, TranslateModule ]
})
export class AppRoutingModule {}
