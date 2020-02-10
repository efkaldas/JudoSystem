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

const password = new FormControl('', Validators.required);
const confirmPassword = new FormControl('', CustomValidators.equalTo(password));

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public form: FormGroup;
  organizationTypes: OrganizationType[];
  submitted = false;
  constructor(private organizationService: OrganizationTypeService, private userService: UserService, private fb: FormBuilder, private router: Router) {}

  ngOnInit() {
    this.getOrganizationTypes();
    this.form = this.fb.group({
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
      email: [
        null,
        Validators.compose([Validators.required, CustomValidators.email])
      ],
      password: [null, Validators.compose([Validators.required])],
      confirmPassword: [null, Validators.compose([Validators.required])]
    });
  }
  private getOrganizationTypes()
  {
    return this.organizationService.getOrganizationTypes()
    .subscribe(
      data => {
        this.organizationTypes = data as OrganizationType[];
        console.log( this.organizationTypes);
      })
  }

  onSubmit() {
    this.submitted = true;
  }
}
