import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { GenderService } from '../../../services/gender.service';
import { Gender } from '../../../data/gender.data';
import { MatSnackBar, MatTableDataSource, MatDialog, MatSort, MatPaginator } from '@angular/material';
import { UserService } from '../../../services/user.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidators } from 'ng2-validation';
import { User } from '../../../data/user.data';
import { CoachService } from '../../../services/coach.service';
import { LoginService } from '../../../services/Login.service';
import { DanKyu } from '../../../data/DanKyu.data';
import { DanKyuService } from '../../../services/dan-kyu.service';


const Password = new FormControl('', Validators.required);
const ConfirmPassword = new FormControl('', CustomValidators.equalTo(Password));

@Component({
  selector: 'app-coach',
  templateUrl: './coach.component.html',
  styleUrls: ['./coach.component.scss']
})
export class CoachComponent implements OnInit {
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  userForm: FormGroup;

  public judokaForm: FormGroup;
  public judokaEditForm: FormGroup;
  genders: Gender[];
  danKyus: DanKyu[];
  selectedElement: any;
  errorMessage: string;
  message: string;
  coaches: User[];
  dataSource = new MatTableDataSource;
  source : MatTableDataSource<User>;
  currentUser: User;
  clicked = false;
  displayedColumns: string[] = ['position','firstname', 'lastname', 'birthDate', 'gender','email', 'danKyu',
   'phoneNumber', 'status', 'actions'];

  constructor(private danKyuService: DanKyuService, private loginService: LoginService, private genderService: GenderService, private coachService: CoachService,
     private fb: FormBuilder, private router: Router,public dialog: MatDialog, private _snackBar: MatSnackBar) { }


  ngOnInit() {
    this.getGenders();
    this.getDanKyus();
    this.getCoaches();
    this.formGroup();
  }
  public openDialog(templateRef: TemplateRef<any>, element: User) {
    this.selectedElement = element;
    this.dialog.open(templateRef);
  }
  public onNoClick(){
    this.selectedElement = null;
    this.dialog.closeAll()
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 4000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  private formGroup()
  {
    this.currentUser = this.loginService.getUser()
    this.userForm = this.fb.group({
      firstname: [null, Validators.compose([Validators.required])],
      lastname: [null, Validators.compose([Validators.required])],
      phoneNumber: [null, Validators.compose([Validators.required])],
      birthDate: [null, Validators.compose([Validators.required])],
      roleId: 2,
      genderId: [null, Validators.compose([Validators.required])],
      danKyuId: [null, Validators.compose([Validators.required])],
      email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      statusId: 1,
      password: Password,
      confirmPassword: ConfirmPassword
    });
  }

  private getCoaches() {
    return this.coachService.getMy()
      .subscribe(
        data => {
          this.coaches = data as User[];
          this.dataSource = new MatTableDataSource(this.coaches);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          console.log(this.dataSource);
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  public blockConfirm()
  {
    return this.coachService.block(this.selectedElement.id)
      .subscribe(
        data => {
          this.openSnackBar("Coach has been blocked", 'CLOSE');
          this.getCoaches();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }
  public registerCoach()
  {
    if(this.userForm.valid) 
    {   
    return this.coachService.create(this.userForm.value)
      .subscribe(
        data => {
          this.openSnackBar("New coach has been registered", 'CLOSE');
          this.getCoaches();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
    }
    else
    {
      this.clicked = true;
    }
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

}
