import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
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
  organizationTypes: OrganizationType[];
  roles: Role[];
  organizationData: Organization;
  userData: User= new User();
  submitted = false;
  clicked = false;
  errorMessage: string;

  constructor(private organizationService: OrganizationTypeService,
    private roleService: RoleService, private userService: UserService, private fb: FormBuilder, private router: Router) {}

  ngOnInit() {
    this.getOrganizationTypes();
    this.getRoles();
    this.formGroup();
  }
  private formGroup()
  {
    this.userForm = this.fb.group({
      firstname: [
        null,
        Validators.compose([Validators.required])
      ],
      lastname: [
        null,
        Validators.compose([Validators.required])
      ],
      phoneNumber: [
        null,
        Validators.compose([Validators.required])
      ],
      userRoles: [
        null,
        Validators.compose([Validators.required])
      ],
      email: [
        null,
        Validators.compose([Validators.required, CustomValidators.email])
      ],
      password: Password,
      confirmPassword: ConfirmPassword
    });
    this.organizationForm = this.fb.group({
      organizationTypeId: [
        null,
        Validators.compose([Validators.required])
      ],
      name: [
        null,
        Validators.compose([Validators.required])
      ],
      country: [
        null,
        Validators.compose([Validators.required])
      ],
      city: [
        null,
        Validators.compose([Validators.required])
      ]
    });
  }
  private getOrganizationTypes()
  {
    return this.organizationService.getOrganizationTypes()
    .subscribe(
      data => {
        this.organizationTypes = data as any;
      })
  }
  private getRoles()
  {
    return this.roleService.getRoles()
    .subscribe(
      data => {
        this.roles = data as any;
      })
  }

  onUserFormSubmit()
  {
    this.clicked = true;
    this.userData = this.userForm.value;
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.userForm.valid);
    console.log(this.organizationForm.valid);

    if (this.userForm.valid && this.organizationForm.valid) {
      return this.userService.registerUser(this.userData, this.organizationForm.value).subscribe(
        data =>
        {
          console.log(data); //gives an object at this point

        },
        error => 
        {
          this.errorMessage = error['error'].message;
          console.log(error); //gives an object at this point
        }
        );
    }
  }
}
