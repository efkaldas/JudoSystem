import { Component, OnInit } from '@angular/core';
import { CompetitionsService } from '../../../../services/Competitions.service';
import { ActivatedRoute } from '@angular/router';
import { Competitions } from '../../../../data/competitions.data';

@Component({
  selector: 'app-competitions-info',
  templateUrl: './competitions-info.component.html',
  styleUrls: ['./competitions-info.component.css']
})
export class CompetitionsInfoComponent implements OnInit {

  competitions: Competitions;
  errorMessage: string;
  competitionsId: number;
  routeSub: any;
  
  constructor(private competitionsService: CompetitionsService, private route: ActivatedRoute) {
    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
   }

  ngOnInit() {
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
