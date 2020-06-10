import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { CompetitionsShowComponent } from '../competitions-show.component';
import * as jspdf from 'jspdf';     

@Component({
  selector: 'app-my-contestants-export',
  templateUrl: './my-contestants-export.component.html',
  styleUrls: ['./my-contestants-export.component.css']
})
export class MyContestantsExportComponent {

  @ViewChild('htmlData', {static:true}) htmlData:ElementRef;
  
  ngOnInit() {
  }

}
