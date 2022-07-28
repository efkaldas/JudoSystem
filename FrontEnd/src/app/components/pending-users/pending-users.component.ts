import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { PendingUserService } from '../../../services/pending-user.service';
import { User } from '../../../data/user.data';
import { Organization } from '../../../data/organization.data';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';
import { GenderService } from '../../../services/gender.service';
import { Router } from '@angular/router';
import { Gender } from '../../../enums/gender.enum';


@Component({
  selector: 'app-pending-users',
  templateUrl: './pending-users.component.html',
  styleUrls: ['./pending-users.component.scss']
})
export class PendingUsersComponent implements OnInit {

  pengingUsers: User[];
  organization: Organization;
  selectedElement: any;
  errorMessage: string;
  message: string;
  dataSource = new MatTableDataSource;
  source : MatTableDataSource<User>;

  genders = [];
  gender = Gender;

  displayedColumns: string[] = ['position','firstname', 'lastname', 'phoneNumber', 'email', 'organizationName', 
   'organizationType', 'address', 'actions'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private pendingUserService : PendingUserService, private genderService: GenderService,
     private router: Router, public dialog: MatDialog, private _snackBar: MatSnackBar) { 
      this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
     }

  ngOnInit() {
    this.getPendingUsers();
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

  public approve(element: User)
  {
    element.statusId = 1;
    return this.pendingUserService.update(element.id, element)
    .subscribe(
      data => {
        this.openSnackBar("User successfully approved!", 'CLOSE');
        this.getPendingUsers();
        this.onNoClick();
      },
      error => {
        this.errorMessage = error["error"].message;
        this.openSnackBar(this.errorMessage, 'CLOSE');
        console.log(error); //gives an object at this point
      }
    );
  }

  public deletionConfirm()
  {
    return this.pendingUserService.delete(this.selectedElement.id)
      .subscribe(
        data => {
          this.openSnackBar("User has been deleted", 'CLOSE');
          this.getPendingUsers();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }

  private getPendingUsers() {
    return this.pendingUserService.getAll()
      .subscribe(
        data => {
          this.pengingUsers = data as User[];
          this.dataSource = new MatTableDataSource(this.pengingUsers);
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

}
