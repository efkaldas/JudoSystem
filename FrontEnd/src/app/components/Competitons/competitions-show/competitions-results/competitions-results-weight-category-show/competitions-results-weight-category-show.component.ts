import { Component, OnInit, ViewChild, ElementRef, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import { WeightCategoryService } from '../../../../../services/weight-category.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { Judoka } from '../../../../../data/judoka.data';

@Component({
  selector: 'app-competitions-results-weight-category-show',
  templateUrl: './competitions-results-weight-category-show.component.html',
  styleUrls: ['./competitions-results-weight-category-show.component.css']
})
export class CompetitionsResultsWeightCategoryShowComponent implements OnInit {

  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild('htmlData',{static: true}) htmlData:ElementRef;

  weightCategoryId: number;
  routeSub: any;


  dataSource = new MatTableDataSource;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'organization', 'country'];

  judokas: Judoka[] = [];
  errorMessage: string;

  constructor(private weightCategoryService: WeightCategoryService, private router: Router, private _snackBar: MatSnackBar,
     private route: ActivatedRoute, private titleService: Title, private changeDetectorRefs: ChangeDetectorRef) { 

    this.routeSub = this.route.params.subscribe(params => {
      this.weightCategoryId = params['categoryId'] as number;
      this.dataSource = null;
      this.getWeightResults();
    });
  }

  ngOnInit() {
  }

  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }

  private getWeightResults()
  {
    return this.weightCategoryService.getResults(this.weightCategoryId)
      .subscribe(
        data => {
          this.judokas = data as any;
          this.dataSource = new MatTableDataSource(this.judokas);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          this.changeDetectorRefs.detectChanges();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }

}
