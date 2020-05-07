import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../data/user.data';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatSnackBar } from '@angular/material';
import { CoachService } from '../../../services/coach.service';

@Component({
  selector: 'app-users-coaches',
  templateUrl: './user-coaches.component.html',
  styleUrls: ['./user-coaches.component.css']
})
export class UserCoachesComponent implements OnInit {

  coaches: User[];
  selectedElement: any;
  dataSource = new MatTableDataSource;
  source : MatTableDataSource<User>;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'email', 'phoneNumber',
   'status', 'actions'];
  errorMessage: string;

  constructor(private coachService: CoachService, public dialog: MatDialog, private _snackBar: MatSnackBar) { }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.getCoaches();
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

  private getCoaches() {
    return this.coachService.getAll()
      .subscribe(
        data => {
          this.coaches = data as User[];
          this.dataSource = new MatTableDataSource(this.coaches);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
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
  public unBlockConfirm()
  {
    return this.coachService.unBlock(this.selectedElement.id)
      .subscribe(
        data => {
          this.openSnackBar("Coach has been un blocked", 'CLOSE');
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

}
