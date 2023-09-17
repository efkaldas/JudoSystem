import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../data/user.data';
import { CoachService } from '../../../services/coach.service';
import { UserType } from '../../../enums/userType.enum';

@Component({
  selector: 'app-my-judokas-tabs',
  templateUrl: './my-judokas-tabs.component.html',
  styleUrls: ['./my-judokas-tabs.component.css']
})
export class MyJudokasTabsComponent implements OnInit {

  navLinks: any[];
  activeLinkIndex = -1;
  coaches: User[];

  constructor(private router: Router, private coachService: CoachService, private route: ActivatedRoute) { 

    this.navLinks = [
      {
        label: 'MyJudokas',
        link: `./coach/${coachService.getUser().id}`,
        index: 0
      },  
  ];
  }

  ngOnInit(): void {
    if(this.isOrganizationAdministrator || this.isAdministrator()) {
      this.getCoaches();
    }
    this.router.events.subscribe((res) => {
        this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
    if (!(this.router.url.indexOf('/coach') > -1)) {
      this.router.navigate(['coach', this.coachService.getUser().id], { relativeTo: this.route });
    }
  }

  private isOrganizationAdministrator() : boolean
  {
    return this.coachService.getUser() != null && this.coachService.getUser().userRoles.filter(x => x.type == UserType.OrganizationAdmin).length > 0;
  }

  private isAdministrator() : boolean
  {
    return this.coachService.getUser() != null && this.coachService.getUser().userRoles.filter(x => x.type == UserType.Admin).length > 0;
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
