import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private apiService:  LoginService, private router: Router) { }

  ngOnInit() {
      // reset login status
      this.apiService.logout();
      // get return url from route parameters or default to '/'
      this.router.navigate(['/']);  
  }
}