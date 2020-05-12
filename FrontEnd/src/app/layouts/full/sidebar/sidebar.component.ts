import {
  ChangeDetectorRef,
  Component,
  NgZone,
  OnDestroy,
  ViewChild,
  HostListener,
  Directive,
  AfterViewInit,
  OnInit
} from '@angular/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { MediaMatcher } from '@angular/cdk/layout';


import { MenuItems } from '../../../shared/menu-items/menu-items';
import { LoginService } from '../../../../services/Login.service';
import { User } from '../../../../data/user.data';
import { Role } from '../../../../data/user-role.enum.data';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: []
})
export class AppSidebarComponent implements OnDestroy, OnInit {
  public config: PerfectScrollbarConfigInterface = {};
  mobileQuery: MediaQueryList;
  public user: User;
  userMenu: any[];

  private _mobileQueryListener: () => void;
  status: boolean = true;
  
  itemSelect:number[]=[]
  parentIndex : Number;
  childIndex : Number;

  setClickedRow(i,j){
   this.parentIndex=i;
   this.childIndex = j;
  }
  subclickEvent() {
    this.status = true;
  }
  scrollToTop(){
  	document.querySelector('.page-wrapper').scroll({
  	top: 0,
  	left: 0
	});
  }	
  
  constructor(
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    public menuItems: MenuItems
  ) {
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit() {
    this.getUser();
    this.getMenuItems();
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  public getMenuItems(): any[]
  { 
    if(this.user != null && this.user.userRoles.some(x => x.role.roleNameEN == Role.Admin)) {
      return this.menuItems.getAdminMenuitem();
    }
    else if(this.user != null && this.user.userRoles.some(x => x.role.roleNameEN == Role.Coach)) {
      return this.menuItems.getOrganizationAdminMenuitem();
    }
    else {
      return this.menuItems.getGuestMenuitem();
    }
    return null;
  
  }
  

  getUser(){
    if (this.menuItems.isLoggedIn()) {
      this.user = this.menuItems.getUser();
    }

  }
}
