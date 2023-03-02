import { Component, OnInit, ViewChild } from '@angular/core';
import { JudokaService } from '../../services/judoka.service';
import { ActivatedRoute } from '@angular/router';
import { Judoka } from '../../data/judoka.data';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Gender } from '../../enums/gender.enum';
import { OrganizationType } from '../../enums/organizationType';

@Component({
  selector: 'app-judoka-profile',
  templateUrl: './judoka-profile.component.html',
  styleUrls: ['./judoka-profile.component.css']
})
export class JudokaProfileComponent implements OnInit {

  routeSub: any;
  judokaId: number;
  judoka: Judoka;
  history: any[];
  errorMessage: string;
  genders = [];
  gender = Gender;
  organizationTypes = [];
  organizationType = OrganizationType;

  dataSource = new MatTableDataSource;
  source : MatTableDataSource<Judoka>;
  displayedColumns: string[] = ['position', 'competitions', 'ageGroup', 'date', 'place'];

  constructor(private judokaService: JudokaService, private route: ActivatedRoute) { 
    this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
    this.organizationTypes = Object.values(this.organizationType).filter((o) => typeof o == 'number');
  }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.judokaId = params['id'] as number;
    });
    this.getJudoka();
    this.getJudokaHistory();
  }
  private getJudoka() {
    return this.judokaService.get(this.judokaId)
      .subscribe(
        data => {
          this.judoka = data as Judoka;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  private getJudokaHistory() {
    return this.judokaService.getJudokasHistory(this.judokaId)
      .subscribe(
        data => {
          this.history = data as any[];
          this.dataSource = new MatTableDataSource(this.history);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
