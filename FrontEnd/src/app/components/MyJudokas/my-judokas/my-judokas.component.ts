import { Component, OnInit, ViewChild, TemplateRef, OnDestroy } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { Judoka } from "../../../data/judoka.data";
import { JudokaService } from "../../../services/judoka.service";
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatSnackBar } from '@angular/material';
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
import { DanKyu } from "../../../data/danKyu.data";
import { DanKyuService } from "../../../services/dan-kyu.service";
import { Gender } from "../../../enums/gender.enum";
import { CoachService } from "../../../services/coach.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-my-judokas",
  templateUrl: "./my-judokas.component.html",
  styleUrls: ["./my-judokas.component.scss"]
})
export class MyJudokasComponent implements OnDestroy  {

  public judokaForm: FormGroup;
  public judokaEditForm: FormGroup;
  myJudokas: Judoka[];
  routeSub: any;
  userId: number;
  genders = [];
  gender = Gender;
  danKyus: DanKyu[];
  selectedElement: any;
  errorMessage: string;
  message: string;
  mySubscription: any;
  dataSource = new MatTableDataSource;
  source : MatTableDataSource<Judoka>;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'birthYears', 'danKyu', 'actions'];

  constructor(private danKyuService: DanKyuService
    , private judokaService: JudokaService
    , private coachService: CoachService
    , private router: Router
    , public dialog: MatDialog
    , private _snackBar: MatSnackBar
    , private fb: FormBuilder
    , private route: ActivatedRoute
    ) {
      this.router.routeReuseStrategy.shouldReuseRoute = function () {
        return false;
      };
      this.routeSub = this.route.params.subscribe(params => {
        this.userId = params['userId'] as number;
      });
     this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
     this.getJudokas();
     this.getDanKyus();
     this.formGroup();
    }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  openDialog(templateRef: TemplateRef<any>, element: Judoka) {
    this.selectedElement = element;
    if(this.selectedElement != null) {
      this.formEditGroup();
    } 
    else{
      this.formGroup();
    } 
    this.dialog.open(templateRef);
  }
  onNoClick(){
    this.selectedElement = null;
    this.dialog.closeAll()
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  compare(o1: any, o2: any) {
    return (o1 == o2);
  }

  private formGroup()
  {
    this.judokaForm = this.fb.group({
      firstname: [null, Validators.compose([Validators.required])],
      lastname: [null, Validators.compose([Validators.required])],
      gender: [null, Validators.compose([Validators.required])],
      birthYears: [null, Validators.compose([Validators.required])],
      dankyuId: [null, Validators.compose([Validators.required])],
      userId: this.userId
    });
  }
  private formEditGroup()
  {
    this.judokaEditForm = this.fb.group({
      firstname: [this.selectedElement.firstname, Validators.compose([Validators.required])],
      lastname: [this.selectedElement.lastname, Validators.compose([Validators.required])],
      gender: [this.selectedElement.gender, Validators.compose([Validators.required])],
      birthYears: [this.selectedElement.birthYears, Validators.compose([Validators.required])],
      dankyuId: [this.selectedElement.danKyuId, Validators.compose([Validators.required])],
      userId: this.userId
    });
  }
  public deletionConfirm()
  {
    return this.judokaService.delete(this.selectedElement.id)
      .subscribe(
        data => {
          this.openSnackBar("Judoka deleted", 'CLOSE');
          this.getJudokas();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }
  public addJudoka()
  {
    if(this.judokaForm.valid)    
    {
    return this.judokaService.create(this.judokaForm.value)
      .subscribe(
        data => {
          this.openSnackBar("New judoka added", 'CLOSE');
          this.getJudokas();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
    }
  }

  public editJudoka()
  { 
    if (this.judokaEditForm.valid && this.selectedElement != null) { 
      return this.judokaService.update(this.selectedElement.id, this.judokaEditForm.value)
        .subscribe(
          data => {
            this.openSnackBar("Judoka has been updated", 'CLOSE');
            this.getJudokas();
            this.onNoClick();
          },
          error => {
            this.errorMessage = error["error"].message;
            this.openSnackBar(this.errorMessage, 'CLOSE');
            console.log(error); //gives an object at this point
          }
        );
    }
  }
  private getJudokas() {
    return this.coachService.getJudokas(this.userId)
      .subscribe(
        data => {
          this.myJudokas = data as Judoka[];
          this.dataSource = new MatTableDataSource(this.myJudokas);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  private getDanKyus()
  {
    return this.danKyuService.getAll()
    .subscribe(
      data => {
        this.danKyus = data as any;
      })
  }
}
