import { Component, OnInit, TemplateRef } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatSnackBar, MatChipInputEvent } from '@angular/material';
import { FormGroup, FormControl } from '@angular/forms';
import { ENTER, COMMA } from '@angular/cdk/keycodes';

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
  
  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog(templateRef: TemplateRef<any>) {
    this.dialog.open(templateRef);
  }
  genders: any[] = [
    {value: 1, viewValue: 'Man'},
    {value: 2, viewValue: 'Woman'},
  ];

  separatorKeysCodes = [ENTER, COMMA];

  categories = [{ name: 'Lemon' }, { name: 'Lime' }, { name: 'Apple' }];

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
    YearsTo: new FormControl('')
  });
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our fruit
    if ((value || '').trim()) {
      this.categories.push({ name: value.trim() });
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }
  onNoClick(){
    this.dialog.closeAll()
  }

  remove(fruit: any): void {
    const index = this.categories.indexOf(fruit);

    if (index >= 0) {
      this.categories.splice(index, 1);
    }
  }

}
