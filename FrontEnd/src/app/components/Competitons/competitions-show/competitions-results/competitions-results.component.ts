import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatTableDataSource } from '@angular/material';
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
  file = null;

  constructor(private competitionsService: CompetitionsService, private route: ActivatedRoute,
     private titleService: Title, private snackBar: MatSnackBar) { 

    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.getAgeGroups();

  }

  ngOnInit() {
  }

  public openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
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

  resultsFileUpload() {
    if (this.file == null) {
      this.errorMessage = "Select file first";
      this.openSnackBar(this.errorMessage, 'CLOSE');
    } else if (this.file.name.substr(this.file.name.length - 4) != ".pdf") {
      this.errorMessage = "File format must be *.pdf";
      this.openSnackBar(this.errorMessage, 'CLOSE');
    } else {
      this.competitionsService.importResultsFile(this.file, this.competitionsId).subscribe(
        data => {
          this.errorMessage = "File has successfully been uploaded";
          this.openSnackBar(this.errorMessage, 'CLOSE');
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
        );
    }  
  }
  fileChange(event) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
        this.file = fileList[0]; 
    }
    else {

    }
  }

}
