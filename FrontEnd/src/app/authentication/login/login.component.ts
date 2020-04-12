import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { LoginService } from '../../../services/Login.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserService } from '../../../services/user.service';
import { User } from '../../../data/user.data';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  errorMessage: string;
  message: string;
  token: any;

  constructor(private userService: UserService, private loginService: LoginService, private fb: FormBuilder, private router: Router, private _snackBar: MatSnackBar) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      password: [null, Validators.compose([Validators.required])]
    });
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 4000,
    });
  }

  onSubmit()
  {
    if (this.loginForm.valid) {
      return this.loginService.login(this.loginForm.value).subscribe(
        data =>
        {
          this.loginService.setToken(data['token']);
          this.token = jwt_decode(data['token']);
          return this.userService.get(
            this.token['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']).subscribe(
            data =>
            {
              this.loginService.setUser(data as User);
              this.message = "Login success" ;
              this.openSnackBar(this.message, "close") ;              
              this.router.navigate(["/myjudokas"]);
            },
            error => 
            {
              this.errorMessage = error['error'].message;
              this.openSnackBar(this.errorMessage, "close")   
            }
            );
        },
        error => 
        {
          this.errorMessage = error['error'].message;
          this.openSnackBar(this.errorMessage, "close")   
        }
        );
    }
  }
}
