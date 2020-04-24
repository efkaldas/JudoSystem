import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { CustomValidators } from 'ng2-validation';
import { CompetitionsService } from '../../../services/Competitions.service';
import { CompetitionsTypeService } from '../../../services/competitions-type.service';
import { CompetitionsType } from '../../../data/competitions-type.data';

@Component({
  selector: 'app-new-competitions',
  templateUrl: './new-competitions.component.html',
  styleUrls: ['./new-competitions.component.css']
})
export class NewCompetitionsComponent implements OnInit {

  public competitionsForm: FormGroup;
  public errorMessage: string;
  public competitionsTypes: CompetitionsType[];

  constructor(private competitionsService: CompetitionsService, private fb: FormBuilder, 
    private competitionsTypeService: CompetitionsTypeService, private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.formGroup();
    this.getCompetitionsTypes();
  }

  private formGroup()
  {
    this.competitionsForm = this.fb.group({
      title: [null, Validators.compose([Validators.required])],
      place: [null, Validators.compose([Validators.required])],
      competitionsDate: [null, Validators.compose([Validators.required])],
      competitionsTime: [null, Validators.compose([Validators.required])],
      entryFee: [false, Validators.compose([Validators.required])],
      cardPayment: [null, Validators.compose([Validators.required])],
      competitionsTypeId: [null, Validators.compose([Validators.required])],
      registrationStart: [null, Validators.compose([Validators.required])],
      registrationStartTime: [null, Validators.compose([Validators.required])],
      registrationEnd: [null, Validators.compose([Validators.required])],
      registrationEndTime: [null, Validators.compose([Validators.required])],
      description: [null, Validators.compose([Validators.required])],
    });
  }
  private normalizeDate()
  {
    this.competitionsForm.value.competitionsDate = this.competitionsForm.value.competitionsDate + " " 
    + this.competitionsForm.value.competitionsTime;

    this.competitionsForm.value.registrationStart = this.competitionsForm.value.registrationStart + " " 
    + this.competitionsForm.value.registrationStartTime;

    this.competitionsForm.value.registrationEnd = this.competitionsForm.value.registrationEnd + " " 
    + this.competitionsForm.value.registrationEndTime;
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  private getCompetitionsTypes()
  {
    return this.competitionsTypeService.getAll()
    .subscribe(
      data => {
        this.competitionsTypes = data as CompetitionsType[];
      })
  }
  public addCompetitions()
  {
    this.normalizeDate();
    if(this.competitionsForm.valid)   
    { 
    return this.competitionsService.create(this.competitionsForm.value)
      .subscribe(
        data => {
          this.openSnackBar("New judoka added", 'CLOSE');
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
    }
  }

}
