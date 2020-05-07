import { Routes } from '@angular/router';
import { CompetitionsComponent } from './competitions/competitions.component';

export const CompetitionsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'competitions',
        component: CompetitionsComponent,
        data: {title: 'Competitions',}
      }
    ]
  }
];
