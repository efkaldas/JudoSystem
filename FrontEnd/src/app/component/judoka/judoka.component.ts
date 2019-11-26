import { Component, OnInit, ViewChild } from '@angular/core';
import { JudokaApiService } from '../../services/judoka.service';
import { judokaSettings } from './judoka.settings';
import { Ng2SmartTableModule, LocalDataSource } from 'ng2-smart-table';
import { Judoka } from '../../data/judoka.model';
import { Router } from '@angular/router';
import { DataSource } from '@angular/cdk/table';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-judoka',
  templateUrl: './judoka.component.html',
  styleUrls: ['./judoka.component.scss']
})
export class JudokaComponent implements OnInit {

  constructor(private apiService:  JudokaApiService, private router: Router) { }

  message : string = "";
  settings = judokaSettings;
  judokasList : Judoka[];
  source : MatTableDataSource<Judoka>;
  dataSource = new MatTableDataSource;
  displayedColumns: string[] = ['position', 'lastName', 'firstName', 'gender', 'danKyu', 'actions'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  
  ngOnInit() {
    this.getJudokas();

  }
  public getJudokas()
  {
    return this.apiService.getJudokas()
    .subscribe(
      data => {
        if (data['status'] == 'success')  {
          this.judokasList = data['response'] as Judoka[];
          this.dataSource = new MatTableDataSource(this.judokasList);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        } else {
          this.message = data['message'];
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
