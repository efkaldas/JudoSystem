import { Component, OnInit } from '@angular/core';
import { LoginApiService } from '../../services/login.service';
import { Login } from '../../data/login.model';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private apiService:  LoginApiService, private route: ActivatedRoute,
    private router: Router) { }
  model: any = {};
  returnUrl: string;
  loading = false;
  errorMsg: string;

  ngOnInit() {

      // reset login status
      this.apiService.logout();
      // get return url from route parameters or default to '/'
      this.router.navigate(['/judokas']);  
  }
  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });
  user : Login;
  message : string = "";
}
