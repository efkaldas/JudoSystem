import { Component, OnInit } from '@angular/core';
import { GenderService } from '../../../services/gender.service';
import { Gender } from '../../../data/gender.data';
import { MatSnackBar } from '@angular/material';
import { UserService } from '../../../services/user.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidators } from 'ng2-validation';


const Password = new FormControl('', Validators.required);
const ConfirmPassword = new FormControl('', CustomValidators.equalTo(Password));

@Component({
  selector: 'app-coach',
  templateUrl: './coach.component.html',
  styleUrls: ['./coach.component.css']
})
export class CoachComponent implements OnInit {
  genders: Gender;
  userForm: FormGroup;

  constructor(private genderService: GenderService, private userService: UserService, private fb: FormBuilder, private router: Router,
    private _snackBar: MatSnackBar) { }


  ngOnInit() {
  }
  private formGroup()
  {
    this.userForm = this.fb.group({
      firstname: [null, Validators.compose([Validators.required])],
      lastname: [null, Validators.compose([Validators.required])],
      phoneNumber: [null, Validators.compose([Validators.required])],
      roleId: [null, Validators.compose([Validators.required])],
      genderId: [null, Validators.compose([Validators.required])],
      email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      userStatusId: 1,
      password: Password,
      confirmPassword: ConfirmPassword
    });
  }

  private getCurrentUser()
  {
    return this.genderService.getAll()
    .subscribe(
      data => {
        this.genders = data as any;
      })
  }

  private getGenders()
  {
    return this.genderService.getAll()
    .subscribe(
      data => {
        this.genders = data as any;
      })
  }

}
