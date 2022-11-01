
import { MediaMatcher } from '@angular/cdk/layout';
import { Router } from '@angular/router';
import {
  ChangeDetectorRef,
  Component,
  NgZone,
  OnDestroy,
  ViewChild,
  HostListener,
  Directive
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';
import { MenuItems } from '../../shared/menu-items/menu-items';
import { User } from '../../data/user.data';
import { LoginService } from '../../services/login.service';
import { Language } from '../../data/language.data';

import { PerfectScrollbarConfigInterface, PerfectScrollbarDirective } from 'ngx-perfect-scrollbar';

/** @title Responsive sidenav */
@Component({
  selector: 'app-full-layout',
  templateUrl: 'full.component.html',
  styleUrls: []
})
export class FullComponent implements OnDestroy {
  mobileQuery: MediaQueryList;
  dir = 'ltr';
  green: boolean;
  blue: boolean;
  dark: boolean;
  minisidebar: boolean;
  boxed: boolean;
  danger: boolean;
  showHide: boolean;
  url: string;
  sidebarOpened;
  status = false;

  public currentLanguage: Language = { iso: 'lt', flag: 'fi fi-lt' };
  public languages: Language[] = [ 
    { iso: 'lt', flag: 'fi fi-lt' },
    { iso: 'en', flag: 'fi fi-gb' },
    { iso: 'ru', flag: 'fi fi-ru' },
  ];

  public showSearch = false;

  public config: PerfectScrollbarConfigInterface = {};
  private _mobileQueryListener: () => void;

  clickEvent() {
    this.status = !this.status;
  }

  constructor(
    public router: Router,
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    public menuItems: MenuItems,
    public translate: TranslateService,
  ) {
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    
    translate.addLangs(this.languages.map(x => x.iso));
    translate.setDefaultLang(this.currentLanguage.iso);
    this.currentLanguage = this.languages.find(element => element.iso === translate.currentLang);
  }

  changeLang(language: string) {  
    localStorage.setItem('locale', language);  
    console.log(language);
    this.currentLanguage = this.languages.find(element => element.iso === language);
    window.location.reload();
  } 

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }



  // Mini sidebar
}
