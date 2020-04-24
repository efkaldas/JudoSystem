import { Component, OnInit } from '@angular/core';
import { CompetitionsService } from '../../../services/Competitions.service';
import { Competitions } from '../../../data/competitions.data';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.css']
})
export class CompetitionsComponent implements OnInit {

  public competitions : Competitions[];
  public errorMessage: string;


  constructor(private competitionsService: CompetitionsService) { }

  ngOnInit() {
    this.getCompetitions();
  }
  public registrationStatus(competition: Competitions) : string {
    let regStart = new Date(competition.registrationStart);
    let regEnd = new Date(competition.registrationEnd);
    let currentTime = new Date(Date.now());

    if(regStart > currentTime) {
      return "not_started"
    } else if(regEnd < currentTime)  {
      return "ended"
    } else if(regStart < currentTime && regEnd > currentTime)  {
      return "in_progress"
    }
  }

  private getCompetitions() {
    return this.competitionsService.getAll()
      .subscribe(
        data => {
          this.competitions = data as Competitions[]
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
