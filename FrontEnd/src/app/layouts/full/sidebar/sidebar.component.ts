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
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: []
})
export class AppSidebarComponent implements OnDestroy, OnInit {
  public config: PerfectScrollbarConfigInterface = {};
  mobileQuery: MediaQueryList;
  public user: User;

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
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  getUser(){
    if (this.menuItems.isLoggedIn()) {
      this.user = this.menuItems.getUser();
    }

  }
}
