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
import { saveAs } from 'file-saver';
import { Role } from '../../../../data/user-role.enum.data';

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
  isAdmin = false;

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
  JudokasResults: Judoka[];
  weightCategories: WeightCategory[];
  weightCategoryId: number;
  dataSource = new MatTableDataSource;
  dataSourceCompetitors = new MatTableDataSource;
  dataSourceMyCompetitors = new MatTableDataSource;
  dataSourceResults = new MatTableDataSource;
  ageGroupId: number;
  competitors:any;
  selectedAgeGroup: number;
  myCompetitors: Judoka[];
  source : MatTableDataSource<Judoka>;
  file = null;
  ageGroupIdresult: number;
  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category', 'actions'];
  displayedColumnsMy: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category'];
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
    this.isUserAdmin();
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
     // weightCategories: [null, Validators.compose([Validators.required])],

    });
  }
  private isUserAdmin()
  {
    if(this.weightCategorySerivce.getUser() != null && this.weightCategorySerivce.getUser().userRoles.filter(x => x.role.roleNameEN == Role.Admin))
      this.isAdmin = true;
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
  public getWeightResults($event)
  {
    console.log(this.ageGroupIdresult);
    let weightCategoryId = this.competitions.ageGroups[this.ageGroupIdresult].weightCategories.find(x => x.title == $event.tab.textLabel).id;
    return this.weightCategorySerivce.getResults(weightCategoryId)
      .subscribe(
        data => {
          this.JudokasResults = data as any;
          this.dataSourceResults = new MatTableDataSource(this.JudokasResults);
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
  public printCompetitiors()
  {
    return this.competitionsService.print(this.competitionsId)
      .subscribe(
        data => {
          console.log(data);
          if (data != null)  {
            saveAs(data, "Contestants.csv");
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
  resultsFileUpload() {
    if (this.file == null) {
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
  public addAgeGroup()
  {
    this.normalizeDate();
    this.ageGroupForm.value.weightCategories = this.categories;
    if(this.ageGroupForm.valid)
    {
      console.log("asd");
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
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }
  public getData($event)
  {
    if($event.tab.textLabel == "My Competitors")
    {
      this.getMyCompetitors();
    }
  }
  public getMyCompetitors() {
    return this.competitionsService.getMyCompetitors(this.competitionsId)
      .subscribe(
        data => {
          this.myCompetitors = data as Judoka[];
          this.dataSourceMyCompetitors = new MatTableDataSource(this.myCompetitors);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
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
  public setAgeGroupIdresult($event)
  {
    let selectedGroup = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel);
    this.ageGroupIdresult = this.competitions.ageGroups.indexOf(selectedGroup);
    console.log(this.ageGroupIdresult);
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
  public isRegistrationOpened()
  {
    let regStart = new Date(this.competitions.registrationStart);
    let regEnd = new Date(this.competitions.registrationEnd);
    let currentTime = new Date(Date.now());

    if(regStart > currentTime) {
      return true;
    } else if(regEnd < currentTime)  {
      return true;
    } else if(regStart < currentTime && regEnd > currentTime)  {
      return false;
    }
  }
  public stringDate(date) 
  {
    return new Date(date);
  }
  public isLoggedIn()
  {
    if(this.ageGroupService.isLoggedIn())
      return true;
    else return false
  }
  public registrationStatus() : string {
    let regStart = new Date(this.competitions.registrationStart);
    let regEnd = new Date(this.competitions.registrationEnd);
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
