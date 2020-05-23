import { Component, OnInit, ViewChild } from '@angular/core';
import { JudokaService } from '../../../services/judoka.service';
import { Judoka } from '../../../data/judoka.data';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-judokas-rating',
  templateUrl: './judokas-rating.component.html',
  styleUrls: ['./judokas-rating.component.css']
})
export class JudokasRatingComponent implements OnInit {


  errorMessage: string;
  male = 1;
  female = 2;
  maleJudokas: Judoka[];
  femaleJudokas: Judoka[];
  source : MatTableDataSource<Judoka>;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'birthYears', 'danKyu', 'coach', 'organization', 'points'];

  constructor(private judokaService: JudokaService) { }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  

  ngOnInit() {
    this.getJudokas(this.male);
  }

  private getJudokas(gender: number) {
    return this.judokaService.getByRank(gender)
      .subscribe(
        data => {
          if(gender == 1) {
            this.maleJudokas = data as Judoka[];
            this.source = new MatTableDataSource(this.maleJudokas);
            this.source.sort = this.sort;
            this.source.paginator = this.paginator;
            console.log(this.maleJudokas);
          } else if(gender == 2) {
            this.femaleJudokas = data as Judoka[];
            this.source = new MatTableDataSource(this.femaleJudokas);
            this.source.sort = this.sort;
            this.source.paginator = this.paginator;
          }
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  public getData($event)
  {
    if($event.tab.textLabel == "Male") {
      this.getJudokas(this.male);
    } 
    else if("Female") {
      this.getJudokas(this.female);
    }
  }

}
