import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { LoginService } from "@shared/services/Login.service";
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss']
})
export class ForgotComponent implements OnInit {
  public form: FormGroup;
  public message: string;
  constructor(private fb: FormBuilder, private router: Router, private loginService: LoginService, private snackBar: MatSnackBar,
    private location: Location) {}

  ngOnInit() {
    this.form = this.fb.group({
      email: [ null, Validators.compose([Validators.required, CustomValidators.email]) ],
      clientURI: [window.location.origin + "/reset-password"]
    });
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 4000,
    });
  }

  onSubmit() {
    this.form.valid
    if(this.form.valid) {
      return this.loginService.forgotPassword(this.form.value).subscribe(
        data =>
        {
          this.openSnackBar("The email has been sent", "close")   
          this.router.navigate(['/login']);
        },
        error => 
        {
          this.message = error['error'].message;
          this.openSnackBar(this.message, "close")   
        }
        );
    }
  }
}
