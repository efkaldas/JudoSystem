import { Component, OnInit, TemplateRef } from '@angular/core';
import { Competitions } from '../../../data/competitions.data';
import { CompetitionsService } from '../../../services/competitions.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { UserType } from '../../../enums/userType.enum';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.css']
})
export class CompetitionsComponent implements OnInit {

  public competitions : Competitions[];
  public errorMessage: string;
  selectedElement: number;
  isAdmin = false;


  constructor(private competitionsService: CompetitionsService, public dialog: MatDialog, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getCompetitions();
    this.isUserAdmin();
  }
  openDialog(templateRef: TemplateRef<any>, element: number) {
    this.selectedElement = element;
    this.dialog.open(templateRef);
  }
  onNoClick(){
    this.selectedElement = null;
    this.dialog.closeAll()
  }
  private isUserAdmin()
  {
    if(this.competitionsService.getUser() != null && this.competitionsService.getUser().userRoles.filter(x => x.type == UserType.Admin).length > 0)
      this.isAdmin = true;
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  public deletionConfirm()
  {
    return this.competitionsService.delete(this.selectedElement)
      .subscribe(
        data => {
          this.openSnackBar("Competitions have been removed", 'CLOSE');
          this.getCompetitions();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }
  public registrationStatus(competition: Competitions) : string {
    let regStart = new Date(competition.registrationStart);
    let regEnd = new Date(competition.registrationEnd);
    let currentTime = new Date(Date.now());

    if(regStart > currentTime) {
      return "not_started"
    } else if(regEnd < currentTime)  {
      return "ended"
    } else if(regStart < currentTime && regEnd > currentTime)  {
      return "in_progress"
    }
  }
  public stringDate(date) 
  {
    return new Date(date);
  }

  private getCompetitions() {
    return this.competitionsService.getAll()
      .subscribe(
        data => {
          this.competitions = data as Competitions[]
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
