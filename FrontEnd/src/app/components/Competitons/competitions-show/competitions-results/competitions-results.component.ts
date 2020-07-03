import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { Judoka } from '../../../../../data/judoka.data';
import { CompetitionsService } from '../../../../../services/Competitions.service';
import { AgeGroup } from '../../../../../data/age-group.data';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-competitions-results',
  templateUrl: './competitions-results.component.html',
  styleUrls: ['./competitions-results.component.css']
})
export class CompetitionsResultsComponent implements OnInit {

  navLinks: any[] = [];
  activeLinkIndex = -1;

  competitionsId: number;
  routeSub: any;
  
  ageGroups: AgeGroup[];
  errorMessage: string;

  constructor(private competitionsService: CompetitionsService, private route: ActivatedRoute, private titleService: Title) { 

    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.getAgeGroups();

  }

  ngOnInit() {
  }

  private getAgeGroups() {
    return this.competitionsService.getAgeGroups(this.competitionsId)
      .subscribe(
        data => {
          this.ageGroups = data as AgeGroup[];
          let i = 0;
          this.ageGroups.forEach(element => {
            this.navLinks.push({label:element.title, link: './group/' + element.id, index: i}) 
          });
          i = i + 1;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
