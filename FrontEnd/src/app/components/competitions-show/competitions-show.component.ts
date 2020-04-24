import { Component, OnInit } from '@angular/core';
import { Competitions } from '../../../data/competitions.data';
import { CompetitionsService } from '../../../services/Competitions.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-competitions-show',
  templateUrl: './competitions-show.component.html',
  styleUrls: ['./competitions-show.component.css']
})
export class CompetitionsShowComponent implements OnInit {

  competitions: Competitions;
  errorMessage: string;
  competitionsId: number;
  routeSub: any;

  constructor(private competitionsService: CompetitionsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.getCompetitions();
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

}
