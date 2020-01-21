import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { JudokaApiService } from '../../services/judoka.service';
import { Ng2SmartTableModule, LocalDataSource } from 'ng2-smart-table';
import { Judoka } from '../../data/judoka.model';
import { Router } from '@angular/router';
import { DataSource } from '@angular/cdk/table';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatSnackBar } from '@angular/material';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-judoka',
  templateUrl: './judoka.component.html',
  styleUrls: ['./judoka.component.scss']
})
export class JudokaComponent implements OnInit {

  constructor(private apiService:  JudokaApiService, private router: Router, public dialog: MatDialog,
    private _snackBar: MatSnackBar) { }

  message : string = "";
  judokasList : Judoka[];
  source : MatTableDataSource<Judoka>;
  dataSource = new MatTableDataSource;
  newJudoka: Judoka;
  displayedColumns: string[] = ['Position', 'LastName', 'FirstName', 'Gender', 'DanKyu', 'BirthYears', 'Actions'];
  genders: any[] = [
    {value: 1, viewValue: 'Man'},
    {value: 2, viewValue: 'Woman'},
  ];
  danKyus: any[] = [
    {value: 1, viewValue: '6 KYU'},
    {value: 2, viewValue: '5 KYU'},
    {value: 3, viewValue: '4 KYU'},
    {value: 4, viewValue: '3 KYU'},
    {value: 5, viewValue: '2 KYU'},
    {value: 6, viewValue: '1 KYU'},
    {value: 7, viewValue: '1 DAN'},
    {value: 8, viewValue: '2 DAN'},
    {value: 9, viewValue: '3 DAN'},
    {value: 10, viewValue: '4 DAN'},
    {value: 11, viewValue: '5 DAN'},
    {value: 12, viewValue: '6 DAN'},
    {value: 13, viewValue: '7 DAN'},
    {value: 14, viewValue: '8 DAN'},

  ];

  judokaForm = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Gender: new FormControl('0'),
    DanKyu: new FormControl('0'),
    BirthYears: new FormControl('0')
  });

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  
  ngOnInit() {
    this.getJudokas();
  }
  onNoClick(){
    this.dialog.closeAll()
  }
  
  openDialog(templateRef: TemplateRef<any>) {
    this.dialog.open(templateRef);
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }

  public addJudoka()
  {
    this.newJudoka = this.judokaForm.value;
    return this.apiService.createJudoka(this.newJudoka)
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
          this.getJudokas();
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
   //       this.apiService.logout();        
          this.router.navigate(['/login']);
        } else {
          this.message = error.message;
        } 
      }); 
  }
  
  public getJudokas()
  {
    return this.apiService.getUserJudokas()
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.judokasList = data['response'] as Judoka[];
          this.message = data['message'];
          this.dataSource = new MatTableDataSource(this.judokasList);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        } else {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
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
  public removeJudoka(id)
  {
    console.log(id);
    return this.apiService.removeJudoka(id)
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
          this.getJudokas();
        } else {
          this.message = data['message'];
          this.openSnackBar(this.message, 'CLOSE');
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

}
