import { Routes } from '@angular/router';

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

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
        data: {title: 'Home'}
      },
      {
        path: 'home',
        component: HomeComponent,
        data: {title: 'Home'}
      },
      {
        path: 'myjudokas',
        component: MyJudokasComponent,
        canActivate: [AuthGuard],
        data: {title: 'My Judokas', roles: [Role.Admin, Role.Coach]}
      },
      {
        path: 'my-coaches',
        component: CoachComponent,
        canActivate: [AuthGuard],
        data: {title: 'Coaches', roles: [Role.Admin, Role.Organization_Admin]}
      },
      {
        path: 'users',
        component: UserCoachesComponent,
        canActivate: [AuthGuard],
        data: {title: 'Coaches', roles: [Role.Admin]}
      },
      {
        path: 'coaches/:id',
        component: CoachShowComponent,
        canActivate: [AuthGuard],
        data: {title: 'Coach'}
      },
      {
        path: 'pending-users',
        component: PendingUsersComponent,
        canActivate: [AuthGuard],
        data: {title: 'Pending Users', roles: [Role.Admin]}
      },
      {
        path: 'competitions',
        component: CompetitionsComponent,
        data: {title: 'Competitions'}
      },
      {
        path: 'competitions/:id',
        component: CompetitionsShowComponent,
        data: {title: 'Competitions'}
      },
      {
        path: 'competitions/:id/competitors-export',
        component: MyContestantsExportComponent,
        data: {title: 'Export'}
      },
      {
        path: 'new-competitions',
        component: NewCompetitionsComponent,
        canActivate: [AuthGuard],
        data: {title: 'Create Competitons', roles: [Role.Admin]}
      },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard],
        data: {title: 'Profile'}
      },
      {
        path: 'judoka/:id',
        component: JudokaProfileComponent,
        canActivate: [AuthGuard],
        data: {title: 'Judoka'}
      },
      {
        path: 'judokas/rating',
        component: JudokasRatingComponent,
        canActivate: [AuthGuard],
        data: {title: 'Judokas Rating'}
      },
      {
        path: 'organizations',
        component: OrganizationsComponent,
        canActivate: [AuthGuard],
        data: {title: 'Organizations', roles: [Role.Admin, Role.Organization_Admin]}
      },
  //     {
  //       path: '/dashboards/dashboard1',
  // //      redirectTo: '/dashboards/dashboard1',
  //       pathMatch: 'full'
  //     },
    ]
  },
  {
    path: '',
    component: AppBlankComponent,
    children: [
      {
        path: 'authentication',
        loadChildren:
          './authentication/authentication.module#AuthenticationModule'
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'authentication/404'
  }
];
