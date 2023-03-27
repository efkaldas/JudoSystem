import { Component, OnInit, TemplateRef } from '@angular/core';
import { User } from '../../data/user.data';
import { UserService } from '../../services/user.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatSnackBar, MatDialog } from '@angular/material';
import { CustomValidators } from 'ng2-validation';
import { DanKyuService } from '../../services/dan-kyu.service';
import { GenderService } from '../../services/gender.service';
import { DanKyu } from '../../data/danKyu.data';
import { Gender } from '../../enums/gender.enum';
import { OrganizationType } from '../../enums/organizationType';
import { UserType } from '../../enums/userType.enum';
import { OrganizationService } from '../../services/organization.service';
import { FileUploader } from 'ng2-file-upload/ng2-file-upload';
import { Organization } from '../../data/organization.data';
import { LoginService } from '../../services/login.service';

const URL = 'https://evening-anchorage-3159.herokuapp.com/api/';

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
  profileImage = null;
  organizationImage = null;

  uploader: FileUploader = new FileUploader({
    url: URL,
    isHTML5: true
  });
  hasBaseDropZoneOver = false;
  hasAnotherDropZoneOver = false;


  genders = [];
  gender = Gender;
  organizationTypes = [];
  organizationType = OrganizationType;
  
  constructor(private organizationService: OrganizationService, private danKyuService: DanKyuService, private genderService: GenderService, private userService: UserService,
     private _snackBar: MatSnackBar, private fb: FormBuilder, public dialog: MatDialog, public loginService: LoginService) {
      this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
      this.organizationTypes = Object.values(this.organizationType).filter((o) => typeof o == 'number');
      this.loginService.user.subscribe(user => this.user = user);
    }

    fileOverBase(e: any): void {
      this.hasBaseDropZoneOver = e;
    }

  ngOnInit() {
    this.getDanKyus();
    this.isOrganizationAdminOrAdmin();
  }
  private isOrganizationAdminOrAdmin()
  {
   if(this.user && this.user.userRoles.filter(x => x.type == UserType.Admin ||  x.type == UserType.OrganizationAdmin))
      this.isAdmin = true;
  }
  private formEditGroup()
  {
    this.userEditForm = this.fb.group({
      firstname: [this.user.firstname, Validators.compose([Validators.required])],
      lastname: [this.user.lastname, Validators.compose([Validators.required])],
      gender: [this.user.gender, Validators.compose([Validators.required])],
      dankyuId: [this.user.danKyu.id, Validators.compose([Validators.required])],
      email: [this.user.email, Validators.compose([Validators.required])],
      birthDate: [new Date(this.user.birthDate), Validators.compose([Validators.required])],
      phoneNumber: [this.user.phoneNumber, Validators.compose([Validators.required])],
      password: Password,
      confirmPassword: ConfirmPassword
    });

    this.organizationEditForm = this.fb.group({
      id: [this.user.organization.id],
      type: [this.user.organization.type, Validators.compose([Validators.required])],
      exactName: [this.user.organization.exactName, Validators.compose([Validators.required])],
      country: [this.user.organization.country, Validators.compose([Validators.required])],
      city: [this.user.organization.city, Validators.compose([Validators.required])],
      address: [this.user.organization.address, Validators.compose([Validators.required])],
      image: [this.user.organization.image],
    });
  }

  compare(o1: any, o2: any) {
    return (o1 == o2);
  }

  openDialog(templateRef: TemplateRef<any>) {
    this.formEditGroup();
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

  public updateOrganization()
  {
    if(this.organizationEditForm.valid)    
    {
    return this.organizationService.update(this.organizationEditForm.value.id, this.organizationEditForm.value)
      .subscribe(
        data => {
          this.user.organization = this.organizationEditForm.value;
          this.openSnackBar("Organization has beed udated", 'CLOSE');
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

  public editUser()
  {
    if(this.userEditForm.valid)    
    {
    return this.userService.updateProfile(this.userEditForm.value)
      .subscribe(
        data => {
          this.openSnackBar("Profile has been updated", 'CLOSE');
          this.user = data as User;
          this.loginService.setUser(this.user);
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

  imageChangeProfile(event) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
        this.profileImage = fileList[0]; 
    }
  }

  imageChangeOrganization(event) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
        this.organizationImage = fileList[0]; 
    }
  }

  private checkUploadedImage(image) {
  if (image == null) {
    this.errorMessage = "Select file first";
    this.openSnackBar(this.errorMessage, 'CLOSE');
  } else if (image.name.substr(image.name.length - 4) != ".png" && image.name.substr(image.name.length - 5) != ".jpeg"
              && image.name.substr(image.name.length - 4) != ".jpg") {
    this.errorMessage = "File format must be *.png or *.jpeg or *.jpg";
    this.openSnackBar(this.errorMessage, 'CLOSE');
  } else {
    return true;
  } 
  return false;
}

  public uploadProfileImage() {
    if (this.checkUploadedImage(this.profileImage)) {
      return this.userService.uploadProfileImage(this.profileImage).subscribe(
        data => {
          this.errorMessage = "File has successfully been uploaded";
          this.user = data as User;
          this.loginService.setUser(this.user);
          this.openSnackBar(this.errorMessage, 'CLOSE');
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
        );
    }
  }

  public uploadOrganizationImage() {
    if (this.checkUploadedImage(this.organizationImage)) {
      return this.organizationService.uploadImage(this.organizationImage).subscribe(
        data => {
          this.errorMessage = "File has successfully been uploaded";
          this.user.organization = data as Organization;
          this.loginService.setOrganization(data);
          this.openSnackBar(this.errorMessage, 'CLOSE');
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
        );
    }
    
  return false;
  }
}
