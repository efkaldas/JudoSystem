import { Component, OnInit, TemplateRef } from '@angular/core';
import { User } from '../../../data/user.data';
import { UserService } from '../../../services/user.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatSnackBar, MatDialog } from '@angular/material';
import { CustomValidators } from 'ng2-validation';
import { DanKyuService } from '../../../services/dan-kyu.service';
import { GenderService } from '../../../services/gender.service';
import { DanKyu } from '../../../data/DanKyu.data';
import { Gender } from '../../../data/gender.data';

const Password = new FormControl('', Validators.required);
const ConfirmPassword = new FormControl('', CustomValidators.equalTo(Password));

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  

  user: User;
  danKyus: DanKyu[];
  genders: Gender[];
  errorMessage: string;
  public userEditForm: FormGroup;
  
  constructor(private danKyuService: DanKyuService,private genderService: GenderService, private userService: UserService,
     private _snackBar: MatSnackBar, private fb: FormBuilder, public dialog: MatDialog) { }

  ngOnInit() {
    this.getUser();
    this.getDanKyus();
    this.getGenders();
  }
  private formEditGroup()
  {
    this.userEditForm = this.fb.group({
      firstname: [this.user.firstname, Validators.compose([Validators.required])],
      lastname: [this.user.lastname, Validators.compose([Validators.required])],
      genderId: [this.user.gender.id, Validators.compose([Validators.required])],
      dankyuId: [null, Validators.compose([Validators.required])],
      email: [this.user.email, Validators.compose([Validators.required])],
      birthDate: [new Date(this.user.birthDate), Validators.compose([Validators.required])],
      phoneNumber: [this.user.phoneNumber, Validators.compose([Validators.required])],
      password: Password,
      confirmPassword: ConfirmPassword
    });
  }

  openDialog(templateRef: TemplateRef<any>) {
    this.dialog.open(templateRef);
  }

  onNoClick(){
    this.dialog.closeAll()
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  private getGenders()
  {
    return this.genderService.getAll()
    .subscribe(
      data => {
        this.genders = data as any;
      })
  }
  private getDanKyus()
  {
    return this.danKyuService.getAll()
    .subscribe(
      data => {
        this.danKyus = data as any;
      })
  }
  public editUser()
  {
    if(this.userEditForm.valid)    
    {
    return this.userService.updateProfile(this.userEditForm.value)
      .subscribe(
        data => {
          this.openSnackBar("Profile has been updated", 'CLOSE');
          this.getUser();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
    }
  }

  private getUser() {
    return this.userService.getFull(this.userService.getUser().id)
      .subscribe(
        data => {
          this.user = data as User;
          this.formEditGroup();
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
