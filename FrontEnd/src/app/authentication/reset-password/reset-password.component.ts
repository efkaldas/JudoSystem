import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { LoginService } from '@shared/services/Login.service';
import { MatSnackBar } from '@angular/material';

const Password = new FormControl('', Validators.required);
const ConfirmPassword = new FormControl('', CustomValidators.equalTo(Password));

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  public form: FormGroup;
  public message: string;
  public clicked = false;

  constructor(private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private loginService: LoginService, private snackBar: MatSnackBar) {}

  ngOnInit() {
    this.form = this.fb.group({
      password: Password,
      confirmPassword: ConfirmPassword,
      token: [this.route.snapshot.queryParamMap.get('token')]
    });
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 4000,
    });
  }

  onSubmit() {
    if(this.form.valid) {
      return this.loginService.resetPassword(this.form.value).subscribe(
        data =>
        {
          this.openSnackBar("The password has been reset", "close")   
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
