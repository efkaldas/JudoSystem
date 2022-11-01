import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import { Judoka } from '../../../../data/judoka.data';
import { CompetitionsService } from '../../../../services/competitions.service';
import { ActivatedRoute } from '@angular/router';
import * as jspdf from 'jspdf';      
import html2canvas from 'html2canvas';  
import { Gender } from '../../../../enums/gender.enum';

@Component({
  selector: 'app-competitions-my-competitors',
  templateUrl: './competitions-my-competitors.component.html',
  styleUrls: ['./competitions-my-competitors.component.css']
})
export class CompetitionsMyCompetitorsComponent implements OnInit {

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild('htmlData',{static: true}) htmlData:ElementRef;

  dataSource = new MatTableDataSource;
  myCompetitors : Judoka[];
  errorMessage: string;
  genders = [];
  gender = Gender;

  competitionsId: number;
  routeSub: any;

  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category'];
  
  constructor(private competitionsService: CompetitionsService, private route: ActivatedRoute,
     private snackBar: MatSnackBar) { 
      this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
      this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
  }

  
  ngOnInit() {
    this.getMyCompetitors();
  }

  public getMyCompetitors() {
    return this.competitionsService.getMyCompetitors(this.competitionsId)
      .subscribe(
        data => {
          this.myCompetitors = data as Judoka[];
          this.dataSource = new MatTableDataSource(this.myCompetitors);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  public openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }

  public downloadPDF() {
    return this.competitionsService.getMycompetitorsPDF(this.competitionsId)
    .subscribe(
      data => {
        if (data != null)  {
          saveAs(data, "MyCompetitors.csv");
          this.openSnackBar("File has been generated", 'CLOSE');
        } else {
          this.openSnackBar("File was not generated", 'CLOSE');
        }
      },
      error => {
        this.errorMessage = error["error"].message;
        this.openSnackBar(this.errorMessage, 'CLOSE');
        console.log(error); //gives an object at this point
      }
    );
  }
  
  // public downloadPDF():void {
  //   let DATA = this.htmlData.nativeElement;
  //   console.log(DATA);
  //   // Get the element to export into pdf
  //   let pdfContent = window.document.getElementById("htmlData");
  //   pdfContent.style.display = 'block';

  //   // Use html2canvas to apply CSS settings
  //   html2canvas(pdfContent).then(function (canvas)
  //   {
  //     var img = canvas.toDataURL("image/png");
  //     var doc = new jspdf();
  //     doc.addImage(img, 'png', 20, 20);
  //     doc.save('test.pdf');
  //   });
  //   pdfContent.style.display = 'none';
  // }

}
