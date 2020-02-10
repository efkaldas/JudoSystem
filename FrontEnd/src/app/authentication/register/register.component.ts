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
  organizationData: Organization;
  userData: User= new User();
  submitted = false;
  clicked = false;
  constructor(private organizationService: OrganizationTypeService, private userService: UserService, private fb: FormBuilder, private router: Router) {}

  ngOnInit() {
    this.getOrganizationTypes();
    this.formGroup();
  }
  private formGroup()
  {
    this.userForm = this.fb.group({
      Firstname: [
        null,
        Validators.compose([Validators.required])
      ],
      Lastname: [
        null,
        Validators.compose([Validators.required])
      ],
      PhoneNumber: [
        null,
        Validators.compose([Validators.required])
      ],
      Email: [
        null,
        Validators.compose([Validators.required, CustomValidators.email])
      ],
      Password: Password,
      ConfirmPassword: ConfirmPassword
    });
    this.organizationForm = this.fb.group({
      Type: [
        0,
        Validators.compose([Validators.required])
      ],
      Name: [
        null,
        Validators.compose([Validators.required])
      ],
      Country: [
        null,
        Validators.compose([Validators.required])
      ],
      City: [
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
        this.organizationTypes = data as OrganizationType[];
        console.log( this.organizationTypes[0].TypeNameEN);
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
        response => console.log(response));
    }
  }
}
