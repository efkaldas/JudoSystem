import { Component, OnInit, TemplateRef } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatSnackBar, MatChipInputEvent } from '@angular/material';
import { FormGroup, FormControl } from '@angular/forms';
import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { EventApiService } from '../../services/event.service';
import { Router } from '@angular/router';
import { Event } from '../../data/event.model';
import { AgeGroup } from '../../data/ageGroup.model';
import { Category } from '../../data/category.model';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  
  constructor(private apiService:  EventApiService, private router: Router, public dialog: MatDialog,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getEvents();
  }

  message : string = "";
  eventsList : Event[];
  source : MatTableDataSource<Event>;
  dataSource = new MatTableDataSource;
  newEvent: Event;
  newGroup: AgeGroup;
  eventId: number;
  newCategories: Category[];
  genders: any[] = [
    {value: 1, viewValue: 'Man'},
    {value: 2, viewValue: 'Woman'},
  ];

  separatorKeysCodes = [ENTER, COMMA];

   categories : Category[] = [{Id:0,Title: "50kg", GroupID:0}];

  eventForm = new FormGroup({
    Title: new FormControl(''),
    Description: new FormControl(''),
    RegistrationStartDate: new FormControl(''),
    RegistrationEndDate: new FormControl(''),
    EventStartDate: new FormControl(''),
    EntryFee: new FormControl('0')
  });

  groupForm = new FormGroup({
    Title: new FormControl(''),
    Gender: new FormControl('0'),
    YearsFrom: new FormControl(''),
    YearsTo: new FormControl(''),
    Categories: new FormControl('')
  });
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our fruit
    if ((value || '').trim()) {
      this.categories.push({ Id:0,Title: value.trim(), GroupID:0 });
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }
  onNoClick(){
    this.dialog.closeAll()
  }
  openDialog(templateRef: TemplateRef<any>, id) {
    this.eventId = id;
    this.dialog.open(templateRef);
  }

  remove(fruit: any): void {
    const index = this.categories.indexOf(fruit);

    if (index >= 0) {
      this.categories.splice(index, 1);
    }
  }
  public addEvent()
  {
    this.newEvent = this.eventForm.value;
    return this.apiService.createEvent(this.newEvent)
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
          this.dialog.closeAll();
        } else {
          this.message = data['message'];
          console.log(this.message);
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
  public addAgeGroup()
  {
    this.newGroup = this.groupForm.value;
    this.newGroup.EventID = this.eventId;
    return this.apiService.createAgeGroup(this.newGroup, this.categories)
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
          this.dialog.closeAll();
        } else {
          this.message = data['message'];
          console.log(this.message);
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
    
  public getEvents()
  {
    return this.apiService.getEventList()
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.eventsList = data['response'] as Event[];
          this.message = data['message'];
          console.log(this.eventsList);
        } else {
          this.message = data['message'];
   //       this.openSnackBar(this.message, 'CLOSE');
        }
      },
      error => {
        if (error.status == 401) {
          console.log(error);
   //       this.apiService.logout();        
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
