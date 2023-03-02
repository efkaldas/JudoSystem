import { Component, OnInit, TemplateRef } from '@angular/core';
import { User } from '../../data/user.data';
import { UserService } from '../../services/user.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatSnackBar, MatDialog } from '@angular/material';
import { CustomValidators } from 'ng2-validation';
import { DanKyuService } from '../../services/dan-kyu.service';
import { GenderService } from '../../services/gender.service';
import { DanKyu } from '../../data/danKyu.data';
import { Role } from '../../data/user-role.enum.data';
import { Gender } from '../../enums/gender.enum';
import { OrganizationType } from '../../enums/organizationType';

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
  errorMessage: string;
  public userEditForm: FormGroup;
  public organizationEditForm: FormGroup;
  isAdmin = false;

  genders = [];
  gender = Gender;
  organizationTypes = [];
  organizationType = OrganizationType;
  
  constructor(private danKyuService: DanKyuService,private genderService: GenderService, private userService: UserService,
     private _snackBar: MatSnackBar, private fb: FormBuilder, public dialog: MatDialog) {
      this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
      this.organizationTypes = Object.values(this.organizationType).filter((o) => typeof o == 'number');
    }

  ngOnInit() {
    this.getUser();
    this.getDanKyus();
    this.isOrganizationAdminOrAdmin()
  }
  private isOrganizationAdminOrAdmin()
  {
   if(this.danKyuService.getUser() != null && this.danKyuService.getUser().userRoles.filter(x => x.role.roleNameEN == Role.Admin ||  x.role.roleNameEN == Role.Organization_Admin))
      this.isAdmin = true;
  }
  private formEditGroup()
  {
    this.userEditForm = this.fb.group({
      firstname: [this.user.firstname, Validators.compose([Validators.required])],
      lastname: [this.user.lastname, Validators.compose([Validators.required])],
      gender: [this.user.gender, Validators.compose([Validators.required])],
      dankyuId: [null, Validators.compose([Validators.required])],
      email: [this.user.email, Validators.compose([Validators.required])],
      birthDate: [new Date(this.user.birthDate), Validators.compose([Validators.required])],
      phoneNumber: [this.user.phoneNumber, Validators.compose([Validators.required])],
      password: Password,
      confirmPassword: ConfirmPassword
    });

    this.organizationEditForm = this.fb.group({
      type: [this.user.organization.type, Validators.compose([Validators.required])],
      exactName: [this.user.organization.exactName, Validators.compose([Validators.required])],
      country: [this.user.organization.country, Validators.compose([Validators.required])],
      city: [this.user.organization.city, Validators.compose([Validators.required])],
      address: [this.user.organization.address, Validators.compose([Validators.required])],
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
