import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../../../data/user.data';
import { CoachService } from '../../../../../services/coach.service';

@Component({
  selector: 'app-competitions-age-groups-tabs',
  templateUrl: './competitions-age-groups-tabs.component.html',
  styleUrls: ['./competitions-age-groups-tabs.component.css']
})
export class CompetitionsAgeGroupsTabsComponent implements OnInit {

  navLinks: any[];
  activeLinkIndex = -1;
  coaches: User[];

  constructor(private router: Router, private coachService: CoachService) { 
    this.navLinks = [
      {
        label: 'MyJudokas',
        link: `./coach/${coachService.getUser().id}`,
        index: 0
      },  
  ];
  }

  ngOnInit(): void {
    this.getCoaches();
    this.router.events.subscribe((res) => {
        this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
  }

  public getCoaches()
  {
    return this.coachService.getMy()
      .subscribe(
        data => {
          this.coaches = data as any[];
          this.navLinks = this.navLinks.concat(this.coaches.map(x => {
            return {
              label: `${x.firstname} ${x.lastname}`,
              link: `./coach/${x.id}`,
              index: x.id,
            }
          }
          ));
        },
        error => {
          // this.errorMessage = error["error"].message;
          // this.openSnackBar(this.errorMessage, 'CLOSE');
          // console.log(error); //gives an object at this point
        }
      );
  }

}
