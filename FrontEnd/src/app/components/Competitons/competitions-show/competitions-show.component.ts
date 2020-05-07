import { Component, OnInit, TemplateRef, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Competitions } from '../../../../data/competitions.data';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatSnackBar, MatChipInputEvent, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { AgeGroup } from '../../../../data/age-group.data';
import { DanKyuService } from '../../../../services/dan-kyu.service';
import { GenderService } from '../../../../services/gender.service';
import { DanKyu } from '../../../../data/DanKyu.data';
import { Gender } from '../../../../data/gender.data';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ENTER, COMMA, SPACE } from '@angular/cdk/keycodes';
import { WeightCategory } from '../../../../data/weight-category.data';
import { AgeGroupService } from '../../../../services/age-group.service';
import { Judoka } from '../../../../data/judoka.data';
import { WeightCategoryService } from '../../../../services/weight-category.service';
import { CompetitionsService } from '../../../../services/Competitions.service';

@Component({
  selector: 'app-competitions-show',
  templateUrl: './competitions-show.component.html',
  styleUrls: ['./competitions-show.component.css']
})
export class CompetitionsShowComponent implements OnInit {

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;

  competitions: Competitions;
  errorMessage: string;
  competitionsId: number;
  routeSub: any;
  selectedElement: any;
  genders: Gender[];
  danKyus: DanKyu[]
  ageGroupForm: FormGroup;
  ageGroups: AgeGroup[];
  competitorCategory: number;
  JudokasToRegister: Judoka[];
  weightCategories: WeightCategory[];
  weightCategoryId: number;
  dataSource = new MatTableDataSource;
  dataSourceCompetitors = new MatTableDataSource;
  ageGroupId: number;
  competitors:any;
  selectedAgeGroup: number;
  source : MatTableDataSource<Judoka>;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category', 'actions'];
  displayedColumnsCompetitors: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'organization', 'country'];

  separatorKeysCodes = [ENTER, COMMA, SPACE];
  categories : WeightCategory[] = [];
  selectedCategory: number[] = [];

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private weightCategorySerivce: WeightCategoryService, private genderService: GenderService, private danKyuService: DanKyuService, 
    private competitionsService: CompetitionsService, private route: ActivatedRoute,
    private ageGroupService: AgeGroupService,
    private router: Router, public dialog: MatDialog, private _snackBar: MatSnackBar, private fb: FormBuilder,
    private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.getDanKyus();
    this.getGenders();
    this.getCompetitions();
    this.formGroup();
  }
  private formGroup()
  {
    this.ageGroupForm = this.fb.group({
      title: [null, Validators.compose([Validators.required])],
      competitionsId: Number(this.competitionsId),
      genderId: [null, Validators.compose([Validators.required])],
      yearsFrom: [null, Validators.compose([Validators.required])],
      yearsTo: [null, Validators.compose([Validators.required])],
      danKyuFrom: [null, Validators.compose([Validators.required])],
      danKyuTo: [null, Validators.compose([Validators.required])],
      competitionsDate: [null, Validators.compose([Validators.required])],
      competitionsTime: [null, Validators.compose([Validators.required])],
      weightInFrom: [null, Validators.compose([Validators.required])],
      weightInFromTime: [null, Validators.compose([Validators.required])],
      weightInTo: [null, Validators.compose([Validators.required])],
      weightInToTime: [null, Validators.compose([Validators.required])],
      weightCategories: [null, Validators.compose([Validators.required])],

    });
  }
  

  openDialog(templateRef: TemplateRef<any>, element: AgeGroup) {
    this.selectedElement = element;
    this.dialog.open(templateRef);
  }
  onNoClick(){
    this.dialog.closeAll()
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.categories.push({ id:0,title: value.trim(), ageGroupId:0 });
    }

    if (input) {
      input.value = '';
    }
  }
  public registerCompetitor(element: any)
  {
    if(this.selectedCategory[element.id] != null)
    {
    return this.weightCategorySerivce.registerCompetitor(this.selectedCategory[element.id], element)
      .subscribe(
        data => {
          this.openSnackBar("New competitor has beed registered", 'CLOSE');
          this.getJudokasToRegister();
          this.changeDetectorRefs.detectChanges();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
    }
    else {
      this.openSnackBar("Please select category", 'CLOSE');
    }
  }
  public cancelRegistration(element: any)
  {
    return this.weightCategorySerivce.deleteCompetitor(element.weightCategories[0].weightCategoryId, element)
      .subscribe(
        data => {
          this.openSnackBar("Registration has been canceled", 'CLOSE');
          this.getJudokasToRegister();
          this.changeDetectorRefs.detectChanges();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }
  public addAgeGroup()
  {
    this.normalizeDate();
    this.ageGroupForm.value.weightCategories = this.categories;
    return this.ageGroupService.create(this.ageGroupForm.value)
      .subscribe(
        data => {
          this.openSnackBar("New age group has been created", 'CLOSE');
          this.categories = [];
    //      this.getJudokas();
          this.onNoClick();
        },
        error => {
          this.errorMessage = error["error"].message;
          this.openSnackBar(this.errorMessage, 'CLOSE');
          console.log(error); //gives an object at this point
        }
      );
  }
  remove(category: any): void {
    const index = this.categories.indexOf(category);

    if (index >= 0) {
      this.categories.splice(index, 1);
    }
  }
  private normalizeDate()
  {
    this.ageGroupForm.value.competitionsDate = this.ageGroupForm.value.competitionsDate + " " 
    + this.ageGroupForm.value.competitionsTime;

    this.ageGroupForm.value.weightInFrom = this.ageGroupForm.value.weightInFrom + " " 
    + this.ageGroupForm.value.weightInFromTime;

    this.ageGroupForm.value.weightInTo = this.ageGroupForm.value.weightInTo + " " 
    + this.ageGroupForm.value.weightInToTime;
  }
  private getGenders()
  {
    return this.genderService.getAll()
    .subscribe(
      data => {
        this.genders = data as any;
      })
  }
  private getDanKyus()
  {
    return this.danKyuService.getAll()
    .subscribe(
      data => {
        this.danKyus = data as any;
      })
  }

  private getAgeGroups() {
    return this.competitionsService.getAgeGroups(this.competitionsId)
      .subscribe(
        data => {
          this.ageGroups = data as AgeGroup[];
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  public getTabRecords($event)
  {
    this.ageGroupId = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel).id;
    this.getJudokasToRegister();
  }

  public getJudokasToRegister() {
    return this.ageGroupService.getJudokasToRegister(this.ageGroupId)
      .subscribe(
        data => {
          this.JudokasToRegister = data as Judoka[];
          this.dataSource = new MatTableDataSource(this.JudokasToRegister);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          console.log(this.JudokasToRegister);
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  public getWeightCategories($event) {
    this.ageGroupId = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel).id;
    return this.ageGroupService.getWeightCategories(this.ageGroupId)
      .subscribe(
        data => {
          this.weightCategories = data as WeightCategory[];
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  public setAgeGroupId($event)
  {
    let selectedGroup = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel);
    this.ageGroupId = this.competitions.ageGroups.indexOf(selectedGroup);
  }
  public getCompetitors($event) {
   this.weightCategoryId = this.competitions.ageGroups[this.ageGroupId].weightCategories.find(x => x.title == $event.tab.textLabel).id;
    return this.weightCategorySerivce.getCompetitors(this.weightCategoryId)
      .subscribe(
        data => {
          this.competitors = data as any[];
          console.log( this.competitors );
          this.dataSourceCompetitors = new MatTableDataSource(this.competitors);
          this.dataSourceCompetitors.sort = this.sort;
          this.dataSourceCompetitors.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
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
