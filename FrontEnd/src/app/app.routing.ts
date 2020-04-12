import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { MyJudokasComponent } from './components/my-judokas/my-judokas.component';
import { AuthGuard } from './auth-guard/auth.guard';
import { PendingUsersComponent } from './components/pending-users/pending-users.component';
import { HomeComponent } from './components/home/home.component';
import { Role } from '../data/user-role.enum.data';

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
        path: 'pending-users',
        component: PendingUsersComponent,
        canActivate: [AuthGuard],
        data: {title: 'Pending Users', roles: [Role.Admin]}
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
