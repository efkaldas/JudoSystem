import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { MyJudokasComponent } from './components/my-judokas/my-judokas.component';
import { AuthGuard } from './auth-guard/auth.guard';
import { PendingUsersComponent } from './components/pending-users/pending-users.component';
import { HomeComponent } from './components/home/home.component';
import { Role } from './data/user-role.enum.data';
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
import { ResetPasswordComponent } from './authentication/reset-password/reset-password.component';

export const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', redirectTo: '/home', pathMatch: 'full', data: {title: 'Home'} },
      { path: 'home', component: HomeComponent, data: {title: 'Home'} },
      { path: 'myjudokas', component: MyJudokasComponent, canActivate: [AuthGuard], data: {title: 'MyJudokas', roles: [Role.Admin, Role.Coach]} },
      { path: 'my-coaches', component: CoachComponent,canActivate: [AuthGuard], data: {title: 'Coaches', roles: [Role.Admin, Role.Organization_Admin]} },
      { path: 'users', component: UserCoachesComponent,canActivate: [AuthGuard], data: {title: 'Users', roles: [Role.Admin]} },
      { path: 'coaches/:id', component: CoachShowComponent, canActivate: [AuthGuard], data: {title: 'Coach'} },
      { path: 'pending-users', component: PendingUsersComponent, canActivate: [AuthGuard], data: {title: 'PendingUsers', roles: [Role.Admin]} },
      { path: 'competitions', component: CompetitionsComponent, data: {title: 'Competitions'} },
      { path: 'competitions/:id', component: CompetitionsTabsComponent, data: {title: 'Competitions'}, 
        children: [
          { path: '', redirectTo: 'info', pathMatch: 'full', data: {title: 'Home'} },
          { path: 'info', component: CompetitionsInfoComponent, data: {title: 'CompetitionsInformation'} },
          { path: 'my-competitors', component: CompetitionsMyCompetitorsComponent, data: {title: 'CompetitionsMyCompetitiors'} },
          { path: 'age-groups', component: CompetitionsAgeGroupsComponent, data: {title: 'CompetitionsAgeGroups'} },
          { path: 'competitors', component: CompetitionsCompetitorsComponent, data: {title: 'Competitors'},
            children: [
              { path: 'group/:groupId', component: CompetitionsResultsWeightCategoriesComponent, data: {title: 'Competitors'},
                children: [
                  { path: 'weight-category/:categoryId', component: CompetitionsResultsWeightCategoryShowComponent, data: {title: 'Competitors'} }
                ] }
              ] },
          { path: 'results', component: CompetitionsResultsComponent, data: {title: 'CompetitionsResults'},
            children: [
              { path: 'group/:groupId', component: CompetitionsResultsWeightCategoriesComponent, data: {title: 'CompetitionsAgeGroups'},
                children: [
                  { path: 'weight-category/:categoryId', component: CompetitionsResultsWeightCategoryShowComponent, data: {title: 'CompetitionsAgeGroups'} }
                ] }
              ] },
          ]},
      { path: 'competitions/:id/competitors-export', component: MyContestantsExportComponent, data: {title: 'Export'} },
      { path: 'new-competitions', component: NewCompetitionsComponent, canActivate: [AuthGuard], data: {title: 'Create Competitons', roles: [Role.Admin]} },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard], data: {title: 'Profile'} },
      { path: 'judoka/:id', component: JudokaProfileComponent, canActivate: [AuthGuard], data: {title: 'Judoka'} },
      { path: 'judokas/rating', component: JudokasRatingComponent, canActivate: [AuthGuard], data: {title: 'Judokas Rating', roles: [Role.Admin]} },
      { path: 'organizations', component: OrganizationsComponent, canActivate: [AuthGuard], data: {title: 'Organizations', roles: [Role.Admin, Role.Organization_Admin]} },
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgot', component: ForgotComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'logout', component: LogoutComponent },
  { path: '404', component: ErrorComponent },
  { path: 'waiting-for-approvement', component: WaitingForApprovementComponent },
  { path: 'not-approved', component: NotApprovedComponent },
  { path: 'permission-denied', component: PermissionDeniedComponent },
  { path: 'user-blocked', component: UserBlockedComponent },
  { path: 'lockscreen', component: LockscreenComponent },
      //Wild Card Route for 404 request
      { path: '**', pathMatch: 'full', 
      component: ErrorComponent },
];
@NgModule({
  imports: [ RouterModule.forRoot(routes), TranslateModule ],
  exports: [ RouterModule, TranslateModule ]
})
export class AppRoutingModule {}
