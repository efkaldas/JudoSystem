import { Component, OnInit } from '@angular/core';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TranslateService } from '@ngx-translate/core';
import { MenuItems } from '../../../shared/menu-items/menu-items';
import { User } from '../../../data/user.data';
import { LoginService } from '../../../services/login.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent implements OnInit{
  public config: PerfectScrollbarConfigInterface = {};
  public user: User;

  ngOnInit() {
  }


  constructor(
    public translate: TranslateService, private loginService : LoginService, public menuItems: MenuItems
  ) {
    this.loginService.user.subscribe(user => this.user = user);
  }

  signOut() {
    this.loginService.logout();
  }
}
