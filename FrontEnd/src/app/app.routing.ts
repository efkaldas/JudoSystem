import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { UserComponent } from './component/user/user.component';
import { LoginComponent } from './component/login/login.component';
import { EventShowComponent } from './component/event-show/event-show.component';
import { EventComponent } from './component/event/event.component';
import { NgModule } from '@angular/core';
import { ButtonsComponent } from './material-component/buttons/buttons.component';
import { GridComponent } from './material-component/grid/grid.component';
import { ListsComponent } from './material-component/lists/lists.component';
import { MenuComponent } from './material-component/menu/menu.component';
import { TabsComponent } from './material-component/tabs/tabs.component';
import { StepperComponent } from './material-component/stepper/stepper.component';
import { ExpansionComponent } from './material-component/expansion/expansion.component';
import { ChipsComponent } from './material-component/chips/chips.component';
import { ToolbarComponent } from './material-component/toolbar/toolbar.component';
import { ProgressSnipperComponent } from './material-component/progress-snipper/progress-snipper.component';
import { ProgressComponent } from './material-component/progress/progress.component';
import { DialogComponent } from './material-component/dialog/dialog.component';
import { TooltipComponent } from '@angular/material';
import { SnackbarComponent } from './material-component/snackbar/snackbar.component';
import { SliderComponent } from './material-component/slider/slider.component';
import { SlideToggleComponent } from './material-component/slide-toggle/slide-toggle.component';
import { JudokaComponent } from './component/judoka/judoka.component';
import { LogoutComponent } from './component/logout/logout.component';
import { RegistrationComponent } from './component/registration/registration.component';
import { AgeGroupComponent } from './component/age-group/age-group.component';


export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
        {
    path: 'button',
    component: ButtonsComponent
  },
  {
    path: 'grid',
    component: GridComponent
  },
  {
    path: 'lists',
    component: ListsComponent
  },
  {
    path: 'menu',
    component: MenuComponent
  },
  {
    path: 'tabs',
    component: TabsComponent
  },
  {
    path: 'stepper',
    component: StepperComponent
  },
  {
    path: 'expansion',
    component: ExpansionComponent
  },
  {
    path: 'chips',
    component: ChipsComponent
  },
  {
    path: 'toolbar',
    component: ToolbarComponent
  },
  {
    path: 'progress-snipper',
    component: ProgressSnipperComponent
  },
  {
    path: 'progress',
    component: ProgressComponent
  },
  {
    path: 'dialog',
    component: DialogComponent
  },
  {
    path: 'tooltip',
    component: TooltipComponent
  },
  {
    path: 'snackbar',
    component: SnackbarComponent
  },
  {
    path: 'slider',
    component: SliderComponent
  },
  {
    path: 'slide-toggle',
    component: SlideToggleComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'judokas',
    component: JudokaComponent
  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'registration',
    component: RegistrationComponent
  },
  {
    path: 'events',
    component: EventComponent
  },
  {
    path: ':id-event-show',
    component: EventShowComponent
  },

    ]
  }
];
@NgModule({
  imports: [ RouterModule.forRoot(AppRoutes, {useHash : true}) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

