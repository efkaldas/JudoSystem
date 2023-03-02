import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../../data/user.data';
import { CoachService } from '../../services/coach.service';
import { Judoka } from '../../data/judoka.data';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Tile } from '../../data/title.data';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Gender } from '../../enums/gender.enum';
import { OrganizationType } from '../../enums/organizationType';

@Component({
  selector: 'app-coach-show',
  templateUrl: './coach-show.component.html',
  styleUrls: ['./coach-show.component.scss']
})
export class CoachShowComponent implements OnInit {

  coach: User;
  errorMessage: string;
  private routeSub: Subscription;
  coachId: number;
  public userImage;
  public organizationlogo;
  genders = [];
  gender = Gender;
  organizationTypes = [];
  organizationType = OrganizationType;


  dataSource = new MatTableDataSource;
  source : MatTableDataSource<Judoka>;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'birthYears', 'gender', 'danKyu'];

  constructor(private coachService : CoachService, private route: ActivatedRoute) { 
    this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
    this.organizationTypes = Object.values(this.organizationType).filter((o) => typeof o == 'number');
  }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.coachId = params['id'] as number;
    });
    this.getCoach();
  }

  private getCoach() {
    return this.coachService.get(this.coachId)
      .subscribe(
        data => {
          this.coach = data as User;
          this.dataSource = new MatTableDataSource(this.coach.judokas);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          this.userImage = require("../../../assets/images/users/" + this.coach.image);
          this.organizationlogo = require("../../../assets/images/organizations/" + this.coach.organization.image);
          console.log(this.organizationlogo);
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
