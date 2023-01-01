import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { Gender } from '../../../../enums/gender.enum';
import { AgeGroup } from '../../../../data/age-group.data';
import { Competitions } from '../../../../data/competitions.data';
import { Judoka } from '../../../../data/judoka.data';
import { Role } from '../../../../data/user-role.enum.data';
import { AgeGroupService } from '../../../../services/age-group.service';
import { CompetitionsService } from '../../../../services/competitions.service';
import { WeightCategoryService } from '../../../../services/weight-category.service';
import { TranslateService } from '@ngx-translate/core';

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
  competitors: Judoka[];
  isAdmin = false;
  genders = [];
  gender = Gender;

  dataSource = new MatTableDataSource;

  displayedColumnsCompetitors: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'organization', 'country'];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  
  constructor(private competitionsService: CompetitionsService
    , private weightCategorySerivce: WeightCategoryService
    , private route: ActivatedRoute
    , private _snackBar: MatSnackBar
    , private translate: TranslateService) { 
    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
  }

  ngOnInit() {
    this.isUserAdmin();
    this.getCompetitions();
    this.dataSource = new MatTableDataSource(this.competitors)
  }

  private isUserAdmin()
  {
    if(this.weightCategorySerivce.getUser() != null && this.weightCategorySerivce.getUser().userRoles.filter(x => x.role.roleNameEN == Role.Admin).length > 0)
      this.isAdmin = true;
  }

  public setAgeGroupId($event)
  {
    let selectedGroup = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel);
    this.ageGroupId = this.competitions.ageGroups.indexOf(selectedGroup);
  }

  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
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

   public printCompetitors()
   {
     return this.competitionsService.print(this.competitionsId)
       .subscribe(
         data => {
           if (data != null)  {
             saveAs(data, "Contestants.csv");
             this.openSnackBar(this.translate.instant("FileHasBeenGenerated"), this.translate.instant("Close"));
            } else {
              this.openSnackBar(this.translate.instant("FileWasNotGenerated"), this.translate.instant("Close"));
            }
         },
         error => {
           this.errorMessage = error["error"].message;
           this.openSnackBar(this.errorMessage, this.translate.instant("Close"));
           console.log(error); //gives an object at this point
         }
       );
   }

}
