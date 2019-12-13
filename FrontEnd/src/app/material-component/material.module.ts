import 'hammerjs';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { DemoMaterialModule } from '../demo-material-module';
import { CdkTableModule } from '@angular/cdk/table';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MaterialRoutes } from './material.routing';
import { ButtonsComponent } from './buttons/buttons.component';

import { GridComponent } from './grid/grid.component';
import { ListsComponent } from './lists/lists.component';
import { MenuComponent } from './menu/menu.component';
import { TabsComponent } from './tabs/tabs.component';
import { StepperComponent } from './stepper/stepper.component';
import { ExpansionComponent } from './expansion/expansion.component';
import { ChipsComponent } from './chips/chips.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { ProgressSnipperComponent } from './progress-snipper/progress-snipper.component';
import { ProgressComponent } from './progress/progress.component';
import {
  DialogComponent,
  DialogOverviewExampleDialogComponent
} from './dialog/dialog.component';
import { TooltipComponent } from './tooltip/tooltip.component';
import { SnackbarComponent } from './snackbar/snackbar.component';
import { SliderComponent } from './slider/slider.component';
import { SlideToggleComponent } from './slide-toggle/slide-toggle.component';
import { JudokaComponent } from '../component/judoka/judoka.component';
import { JudokaApiService } from '../services/judoka.service';
import { LoginComponent } from '../component/login/login.component';
import { LoginApiService } from '../services/login.service';
import { UsersApiService } from '../services/users.service';
import { httpInterceptorProviders } from '../interceptors';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { LogoutComponent } from '../component/logout/logout.component';
import { RegistrationComponent } from '../component/registration/registration.component';
import { RegistrationApiService } from '../services/registration.service';
import { EventComponent } from '../component/event/event.component';
import { EventShowComponent } from '../component/event-show/event-show.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(MaterialRoutes),
    DemoMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    CdkTableModule,
    Ng2SmartTableModule,
  ],
  providers: [LoginApiService, UsersApiService, JudokaApiService, RegistrationApiService, httpInterceptorProviders],
  entryComponents: [DialogOverviewExampleDialogComponent],
  declarations: [
    ButtonsComponent,
    GridComponent,
    ListsComponent,
    MenuComponent,
    TabsComponent,
    StepperComponent,
    ExpansionComponent,
    ChipsComponent,
    ToolbarComponent,
    ProgressSnipperComponent,
    ProgressComponent,
    DialogComponent,
    DialogOverviewExampleDialogComponent,
    TooltipComponent,
    SnackbarComponent,
    SliderComponent,
    SlideToggleComponent,
    LoginComponent,
    JudokaComponent,
    LogoutComponent,
    RegistrationComponent,
    EventComponent,
    EventShowComponent
  ]
})
export class MaterialComponentsModule {}
