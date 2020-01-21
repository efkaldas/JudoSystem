
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { LocationStrategy, PathLocationStrategy, CommonModule } from '@angular/common';
import { AppRoutes, AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FullComponent } from './layouts/full/full.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';

import { SharedModule } from './shared/shared.module';
import { SpinnerComponent } from './shared/spinner.component';
import { LoginComponent } from './component/login/login.component';
import { UserComponent } from './component/user/user.component';
import { httpInterceptorProviders } from './interceptors';
import { UsersApiService } from './services/users.service';
import { JudokaApiService } from './services/judoka.service';
import { LoginApiService } from './services/login.service';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { LayoutModule } from '@angular/cdk/layout';
import { MatTableModule, MatPaginatorModule, MatSortModule, TooltipComponent } from '@angular/material';
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
import { DialogComponent, DialogOverviewExampleDialogComponent } from './material-component/dialog/dialog.component';
import { SnackbarComponent } from './material-component/snackbar/snackbar.component';
import { SliderComponent } from './material-component/slider/slider.component';
import { SlideToggleComponent } from './material-component/slide-toggle/slide-toggle.component';
import { JudokaComponent } from './component/judoka/judoka.component';
import { LogoutComponent } from './component/logout/logout.component';
import { RegistrationComponent } from './component/registration/registration.component';
import { EventComponent } from './component/event/event.component';
import { EventShowComponent } from './component/event-show/event-show.component';
import { RegistrationApiService } from './services/registration.service';
import { EventApiService } from './services/event.service';
import { CdkTableModule } from '@angular/cdk/table';
import { AgeGroupComponent } from './component/age-group/age-group.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    FormsModule,
    FlexLayoutModule,
    SharedModule,
    Ng2SmartTableModule,
 //   RouterModule.forRoot(AppRoutes),
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    LayoutModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    CommonModule,
    DemoMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    CdkTableModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppSidebarComponent,
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
   // TooltipComponent,
    SnackbarComponent,
    SliderComponent,
    SlideToggleComponent,
    LoginComponent,
    JudokaComponent,
    LogoutComponent,
    RegistrationComponent,
    EventComponent,
    EventShowComponent,
    AgeGroupComponent
  ],
  entryComponents: [DialogOverviewExampleDialogComponent],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy,
    },
    LoginApiService, UsersApiService, JudokaApiService, RegistrationApiService,EventApiService, httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
