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
import { CompetitionsComponent } from './components/competitions/competitions.component';
import { NewCompetitionsComponent } from './components/new-competitions/new-competitions.component';
import { CompetitionsShowComponent } from './components/competitions-show/competitions-show.component';
import { ProfileComponent } from './components/profile/profile.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'myjudokas',
        component: MyJudokasComponent,
        canActivate: [AuthGuard],
        data: {title: 'My Judokas', roles: [Role.Admin, Role.Coach]}
      },
      {
        path: 'coaches',
        component: CoachComponent,
        canActivate: [AuthGuard],
        data: {title: 'Coaches', roles: [Role.Admin, Role.Coach]}
      },
      {
        path: 'coaches/:id',
        component: CoachShowComponent,
        canActivate: [AuthGuard],
        data: {title: 'Coach', roles: [Role.Admin, Role.Coach]}
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
        canActivate: [AuthGuard],
        data: {title: 'Competitions',}
      },
      {
        path: 'competitions/:id',
        component: CompetitionsShowComponent,
        canActivate: [AuthGuard],
        data: {title: 'Competitions',}
      },
      {
        path: 'new-competitions',
        component: NewCompetitionsComponent,
        canActivate: [AuthGuard],
        data: {title: 'Create Competitons',}
      },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard],
        data: {title: 'Profile',}
      },
  //     {
  //       path: '/dashboards/dashboard1',
  // //      redirectTo: '/dashboards/dashboard1',
  //       pathMatch: 'full'
  //     },
      {
        path: 'dashboards',
        loadChildren: './dashboards/dashboards.module#DashboardsModule'
      },
      {
        path: 'material',
        loadChildren:
          './material-component/material.module#MaterialComponentsModule'
      },
      {
        path: 'apps',
        loadChildren: './apps/apps.module#AppsModule'
      },
      {
        path: 'forms',
        loadChildren: './forms/forms.module#FormModule'
      },
      {
        path: 'tables',
        loadChildren: './tables/tables.module#TablesModule'
      }, 
      {
        path: 'datatables',
        loadChildren: './datatables/datatables.module#DataTablesModule'
      },
      {
        path: 'pages',
        loadChildren: './pages/pages.module#PagesModule'
      },
      {
        path: 'widgets',
        loadChildren: './widgets/widgets.module#WidgetsModule'
      },
      {
        path: 'charts',
        loadChildren: './charts/chartslib.module#ChartslibModule'
      },
      {
        path: 'multi',
        loadChildren: './multi-dropdown/multi-dd.module#MultiModule'
      }
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
