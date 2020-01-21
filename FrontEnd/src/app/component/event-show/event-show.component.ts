import { Component, OnInit } from '@angular/core';
import { EventApiService } from '../../services/event.service';
import { MatSnackBar, MatDialog, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AgeGroup } from '../../data/ageGroup.model';

@Component({
  selector: 'app-event-show',
  templateUrl: './event-show.component.html',
  styleUrls: ['./event-show.component.css']
})
export class EventShowComponent implements OnInit {

  constructor(private apiService:  EventApiService, private router: Router, public dialog: MatDialog,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getEvent();
    this.getGroups();
    console.log(Number(this.router.url.split("-", 3)[0].replace('/','')));
  }
  message : string = "";
  event : Event;
  eventGroups: AgeGroup[];
  source : MatTableDataSource<Event>;
  dataSource = new MatTableDataSource;
  newEvent: Event;

  public getEvent()
  {
    return this.apiService.getEvent(Number(this.router.url.split("-", 3)[0].replace('/','')))
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.event = data['response'] as Event;
          this.message = data['message'];
          console.log(this.event);
        } else {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
        }
      },
      error => {
        if (error.status == 401) {
          console.log(error);
          this.apiService.logout();        
          this.router.navigate(['/login']);
        } else {
          this.message = error.message;
        } 
      }); 
  }
  public getGroups()
  {
    return this.apiService.getAgeGroupsByEvent(Number(this.router.url.split("-", 3)[0].replace('/','')))
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.eventGroups = data['response'] as AgeGroup[];
          this.message = data['message'];
          console.log(this.event);
        } else {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
        }
      },
      error => {
        if (error.status == 401) {
          console.log(error);
          this.apiService.logout();        
          this.router.navigate(['/login']);
        } else {
          this.message = error.message;
        } 
      }); 
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }


}
