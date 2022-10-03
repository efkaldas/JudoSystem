import { Component, OnInit } from '@angular/core';
import { LoginService } from '@shared/services/Login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }
  public isLoggedIn() {
    if(this.loginService.isLoggedIn()){
      return true;
    }
    else {
      return false
    }
  }

}
