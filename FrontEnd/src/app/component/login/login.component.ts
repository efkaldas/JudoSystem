import { Component, OnInit } from '@angular/core';
import { LoginApiService } from '../../services/login.service';
import { Login } from '../../data/login.model';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private apiService:  LoginApiService, private route: ActivatedRoute,
    private router: Router) { }
  model: any = {};
  returnUrl: string;
  loading = false;
  errorMsg: string;

  ngOnInit() {
    if(this.apiService.isLoggedIn())  
    {
      this.router.navigate(['/judokas']);
    }
    else
    {
      // reset login status
      this.apiService.logout();
      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';     
    }
  }
  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });
  user : Login;
  message : string = "";
  public onSubmit() {
    this.user = this.loginForm.value;
    this.loading = true;
    this.apiService.Login(this.user)
        .subscribe(
            data => {
                if (data['response'] != null && data['status'] == "success") {
                    this.apiService.setToken(data['response']);
                    this.errorMsg = "Login success"           
                    this.router.navigate([this.returnUrl]);
                } else {
                    this.errorMsg = data['message']; 
                } 
                this.loading = false;
            },
            error => {
                this.errorMsg = error.message;
                this.loading = false;
            });
  }

}
