import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { AgeGroup } from '../../../../../data/age-group.data';
import { Competitions } from '../../../../../data/competitions.data';
import { Judoka } from '../../../../../data/judoka.data';
import { AgeGroupService } from '../../../../../services/age-group.service';
import { CompetitionsService } from '../../../../../services/Competitions.service';
import { WeightCategoryService } from '../../../../../services/weight-category.service';

@Component({
  selector: 'app-competitions-competitors',
  templateUrl: './competitions-competitors.component.html',
  styleUrls: ['./competitions-competitors.component.css']
})
export class CompetitionsCompetitorsComponent implements OnInit {

  routeSub: any;
  competitionsId: number;
  errorMessage: any;
  ageGroupId: any;
  competitions: any;
  weightCategoryId: any;
  competitors: unknown[];

  dataSource = new MatTableDataSource;

  displayedColumnsCompetitors: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'organization', 'country'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  
  constructor(private competitionsService: CompetitionsService, private weightCategorySerivce: WeightCategoryService, private route: ActivatedRoute) { 
    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
  }

  ngOnInit() {
    this.getCompetitions();
  }

  public setAgeGroupId($event)
  {
    let selectedGroup = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel);
    this.ageGroupId = this.competitions.ageGroups.indexOf(selectedGroup);
  }

  private getCompetitions() {
    return this.competitionsService.get(this.competitionsId)
      .subscribe(
        data => {
          this.competitions = data as Competitions;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  public getCompetitors($event) {
    this.weightCategoryId = this.competitions.ageGroups[this.ageGroupId].weightCategories.find(x => x.title == $event.tab.textLabel).id;
     return this.weightCategorySerivce.getCompetitors(this.weightCategoryId)
       .subscribe(
         data => {
           this.competitors = data as Judoka[];
           this.dataSource = new MatTableDataSource(this.competitors);
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
