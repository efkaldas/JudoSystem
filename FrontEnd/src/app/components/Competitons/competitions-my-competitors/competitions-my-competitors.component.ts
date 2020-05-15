import { Component, OnInit } from '@angular/core';
import { CompetitionsService } from '../../../../services/Competitions.service';

@Component({
  selector: 'app-competitions-my-competitors',
  templateUrl: './competitions-my-competitors.component.html',
  styleUrls: ['./competitions-my-competitors.component.css']
})
export class CompetitionsMyCompetitorsComponent implements OnInit {

  constructor(private competitionsService: CompetitionsService) { }

  ngOnInit() {
  }


}
