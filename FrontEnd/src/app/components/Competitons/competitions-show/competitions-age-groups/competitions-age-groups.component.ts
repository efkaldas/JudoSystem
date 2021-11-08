import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { AgeGroupService } from '../../../../../services/age-group.service';
import { Judoka } from '../../../../../data/judoka.data';
import { CompetitionsService } from '../../../../../services/Competitions.service';
import { ActivatedRoute } from '@angular/router';
import { Competitions } from '../../../../../data/competitions.data';
import { AgeGroup } from '../../../../../data/age-group.data';

@Component({
  selector: 'app-competitions-age-groups',
  templateUrl: './competitions-age-groups.component.html',
  styleUrls: ['./competitions-age-groups.component.css']
})
export class CompetitionsAgeGroupsComponent implements OnInit {

  competitions: Competitions;
  judokasToRegister: Judoka[];
  errorMessage: string;
  competitionsId: number;
  routeSub: any;
  ageGroupId: number;

  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category', 'actions'];

  dataSource = new MatTableDataSource;

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private ageGroupService: AgeGroupService, private competitionsService: CompetitionsService,
     private route: ActivatedRoute) {
    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
   }

  ngOnInit() {
    this.getAgeGroups();
  }

  public isLoggedIn()
  {
    if(this.competitionsService.isLoggedIn())
      return true;
    else return false
  }

  public getAgeGroups() {
  return this.competitionsService.get(this.competitionsId)
    .subscribe(
      data => {
        this.competitions = data as Competitions;
        // this.dataSource = new MatTableDataSource(data as AgeGroup[]);
        // this.dataSource.sort = this.sort;
        // this.dataSource.paginator = this.paginator;
      },
      error => {
        this.errorMessage = error["error"].message;
        console.log(error); //gives an object at this point
      }
    );
  }
  public getTabRecords($event)
  {
    this.ageGroupId = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel).id;
    this.getJudokasToRegister();
  }

  public getJudokasToRegister() {
    return this.ageGroupService.getJudokasToRegister(this.ageGroupId)
      .subscribe(
        data => {
          this.judokasToRegister = data as Judoka[];
          this.dataSource = new MatTableDataSource(this.judokasToRegister);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  public isRegistrationOpened()
  {
    let regStart = new Date(this.competitions.registrationStart);
    let regEnd = new Date(this.competitions.registrationEnd);
    let currentTime = new Date(Date.now());

    if(regStart > currentTime) {
      return true;
    } else if(regEnd < currentTime)  {
      return true;
    } else if(regStart < currentTime && regEnd > currentTime)  {
      return false;
    }
  }
  public stringDate(date) 
  {
    return new Date(date);
  }

  public registrationStatus() : string {
    if(this.competitions)
    {
      let regStart = new Date(this.competitions.registrationStart);
      let regEnd = new Date(this.competitions.registrationEnd);
      let currentTime = new Date(Date.now());

      if(regStart > currentTime) {
        return "not_started"
      } else if(regEnd < currentTime)  {
        return "ended"
      } else if(regStart < currentTime && regEnd > currentTime)  {
        return "in_progress"
      }
    }
  }

}
