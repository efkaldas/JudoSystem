import { Component, OnInit } from '@angular/core';
import { JudokaService } from '../../../services/judoka.service';
import { ActivatedRoute } from '@angular/router';
import { Judoka } from '../../../data/judoka.data';

@Component({
  selector: 'app-judoka-profile',
  templateUrl: './judoka-profile.component.html',
  styleUrls: ['./judoka-profile.component.css']
})
export class JudokaProfileComponent implements OnInit {

  routeSub: any;
  judokaId: number;
  judoka: Judoka;
  errorMessage: string;

  constructor(private judokaService: JudokaService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.judokaId = params['id'] as number;
    });
    this.getJudoka();
  }
  private getJudoka() {
    return this.judokaService.get(this.judokaId)
      .subscribe(
        data => {
          this.judoka = data as Judoka;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

}
