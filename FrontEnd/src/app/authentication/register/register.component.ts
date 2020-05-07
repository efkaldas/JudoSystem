import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
  FormArray
} from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { Food } from '../../forms/select/select.component';
import { OrganizationTypeService } from '../../../services/organization-type.service';
import { UserService } from '../../../services/user.service';
import { OrganizationType } from '../../../data/organization-type.data';
import { Organization } from '../../../data/organization.data';
import { User } from '../../../data/user.data';
import { RoleService } from '../../../services/role.service';
import { Role } from '../../../data/role.data';
import { UserRole } from '../../../data/user-role.data';
import { GenderService } from '../../../services/gender.service';
import { Gender } from '../../../data/gender.data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DanKyuService } from '../../../services/dan-kyu.service';
import { DanKyu } from '../../../data/DanKyu.data';

const Password = new FormControl('', Validators.required);
const ConfirmPassword = new FormControl('', CustomValidators.equalTo(Password));

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public userForm: FormGroup;
  public organizationForm: FormGroup;
  private control: FormArray;
  organizationTypes: OrganizationType[];
  organizationData: Organization;
  userData: User= new User();
  submitted = false;
  clicked = false;
  danKyus: DanKyu[];
  errorMessage: string;
  message: string;
  genders: Gender[];

  constructor(private organizationService: OrganizationTypeService, private genderService: GenderService,
    private roleService: RoleService, private danKyuService: DanKyuService, private userService: UserService, private fb: FormBuilder, private router: Router,
    private _snackBar: MatSnackBar) {}

  ngOnInit() {
    this.getOrganizationTypes();
    this.getDanKyus();
    this.getGenders();
    this.formGroup();
  }
  private formGroup()
  {
    this.userForm = this.fb.group({
      firstname: [null, Validators.compose([Validators.required])],
      lastname: [null, Validators.compose([Validators.required])],
      phoneNumber: [null, Validators.compose([Validators.required])],
      birthDate: [null, Validators.compose([Validators.required])],
      danKyuId: [null, Validators.compose([Validators.required])],
      genderId: [null, Validators.compose([Validators.required])],
      email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      StatusId: 2,
      password: Password,
      confirmPassword: ConfirmPassword
    });

    this.organizationForm = this.fb.group({
      organizationTypeId: [null, Validators.compose([Validators.required])],
      exactName: [null, Validators.compose([Validators.required])],
      country: [null, Validators.compose([Validators.required])],
      city: [null, Validators.compose([Validators.required])],
      address: [null, Validators.compose([Validators.required])],
    });
  }
  private getOrganizationTypes()
  {
    return this.organizationService.getAll()
    .subscribe(
      data => {
        this.organizationTypes = data as OrganizationType[];
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
  private getDanKyus()
  {
    return this.danKyuService.getAll()
    .subscribe(
      data => {
        this.danKyus = data as any;
      })
  }

  onUserFormSubmit()
  {
    this.clicked = true;
    this.userData = this.userForm.value;
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.userForm.valid && this.organizationForm.valid) {
      return this.userService.registerUser(this.userData, this.organizationForm.value).subscribe(
        data =>
        {
          this.message = "Successfully registered";                
          this.router.navigate(["/authentication/waiting-for-approvement"]);
          this.openSnackBar(this.message, "close");   
        },
        error => 
        {
          this.errorMessage = error['error'].message;
          console.log(error); //gives an object at this point
        }
        );
    }
  }
  createItem(): FormGroup {
    return this.fb.group({
      roleId: ''
    });
  }
}
