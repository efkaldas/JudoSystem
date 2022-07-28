import { ChangeDetectorRef, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatChipInputEvent, MatDialog, MatPaginator, MatSnackBar, MatSort, MatTableDataSource } from '@angular/material';
import { AgeGroupService } from '../../../../../services/age-group.service';
import { Judoka } from '../../../../../data/judoka.data';
import { CompetitionsService } from '../../../../../services/Competitions.service';
import { ActivatedRoute } from '@angular/router';
import { Competitions } from '../../../../../data/competitions.data';
import { AgeGroup } from '../../../../../data/age-group.data';
import { WeightCategoryService } from '../../../../../services/weight-category.service';
import { Role } from '../../../../../data/user-role.enum.data';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WeightCategory } from '../../../../../data/weight-category.data';
import { GenderService } from '../../../../../services/gender.service';
import { DanKyuService } from '../../../../../services/dan-kyu.service';
import { DanKyu } from '../../../../../data/DanKyu.data';
import { COMMA, ENTER, SPACE } from '@angular/cdk/keycodes';
import { Gender } from '../../../../../enums/gender.enum';

@Component({
  selector: 'app-competitions-age-groups',
  templateUrl: './competitions-age-groups.component.html',
  styleUrls: ['./competitions-age-groups.component.css']
})
export class CompetitionsAgeGroupsComponent implements OnInit {

  isAdmin = false;
  selectedElement: any;
  ageGroupForm: FormGroup;
  separatorKeysCodes = [ENTER, COMMA, SPACE];

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;

  competitions: Competitions;
  judokasToRegister: Judoka[];
  errorMessage: string;
  competitionsId: number;
  routeSub: any;
  ageGroupId: number;
  selectedCategory: number[] = [];
  categories : WeightCategory[] = [];
  danKyus: DanKyu[];

  genders = [];
  gender = Gender;

  displayedColumns: string[] = ['position', 'firstname', 'lastname', 'gender', 'danKyu', 'status', 'category', 'actions'];

  dataSource = new MatTableDataSource;

  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  constructor(private ageGroupService: AgeGroupService, private competitionsService: CompetitionsService,
    private weightCategoryService: WeightCategoryService, private route: ActivatedRoute,
    private changeDetectorRefs: ChangeDetectorRef, private snackBar: MatSnackBar, public dialog: MatDialog, private genderService: GenderService,
    private danKyuService: DanKyuService, private fb: FormBuilder,) {
    this.routeSub = this.route.parent.params.subscribe(params => {
      this.competitionsId = params['id'] as number;
    });
    this.genders = Object.values(this.gender).filter((o) => typeof o == 'number');
   }

  ngOnInit() {
    this.isUserAdmin();
    this.formGroup();
    this.getAgeGroups();
    this.getDanKyus();
  }

  public isLoggedIn()
  {
    if(this.competitionsService.isLoggedIn())
      return true;
    else return false
  }

  private formGroup()
  {
    this.ageGroupForm = this.fb.group({
      title: [null, Validators.compose([Validators.required])],
      competitionsId: Number(this.competitionsId),
      gender: [null, Validators.compose([Validators.required])],
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

  openDialog(templateRef: TemplateRef<any>, element: AgeGroup) {
    this.selectedElement = element;
    this.dialog.open(templateRef);
  }
  
  onNoClick(){
    this.dialog.closeAll()
  }

  public openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
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

  remove(category: any): void {
    const index = this.categories.indexOf(category);

    if (index >= 0) {
      this.categories.splice(index, 1);
    }
  }

  private isUserAdmin()
  {
    if(this.competitionsService.getUser() != null && this.competitionsService.getUser().userRoles.filter(x => x.role.roleNameEN == Role.Admin).length > 0)
      this.isAdmin = true;
  }

  public getAgeGroups() {
  return this.competitionsService.get(this.competitionsId)
    .subscribe(
      data => {
        this.competitions = data as Competitions;
        // this.dataSource = new MatTableDataSource(data as AgeGroup[]);
        // this.dataSource.sort = this.sort;
        // this.dataSource.paginator = this.paginator;
      },
      error => {
        this.errorMessage = error["error"].message;
        console.log(error); //gives an object at this point
      }
    );
  }
  public cancelRegistration(element: any)
  {
    return this.weightCategoryService.deleteCompetitor(element.weightCategories[0].weightCategoryId, element)
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

  public registerCompetitor(element: any)
  {
    if(this.selectedCategory[element.id] != null)
    {
    return this.weightCategoryService.registerCompetitor(this.selectedCategory[element.id], element)
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

  public getTabRecords($event)
  {
    this.ageGroupId = this.competitions.ageGroups.find(x => x.title == $event.tab.textLabel).id;
    this.getJudokasToRegister();
  }

  public getJudokasToRegister() {
    return this.ageGroupService.getJudokasToRegister(this.ageGroupId)
      .subscribe(
        data => {
          this.judokasToRegister = data as Judoka[];
          this.dataSource = new MatTableDataSource(this.judokasToRegister);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
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

  public registrationStatus() : string {
    if(this.competitions)
    {
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
  }

  public addAgeGroup()
  {
    this.normalizeDate();
    this.ageGroupForm.value.weightCategories = this.categories;
    if(this.ageGroupForm.valid)
    {
    return this.ageGroupService.create(this.ageGroupForm.value)
      .subscribe(
        data => {
          this.openSnackBar("New age group has been created", 'CLOSE');
          this.categories = [];
          this.getAgeGroups();
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

  private normalizeDate()
  {
    this.ageGroupForm.value.competitionsDate = this.ageGroupForm.value.competitionsDate + " " 
    + this.ageGroupForm.value.competitionsTime;

    this.ageGroupForm.value.weightInFrom = this.ageGroupForm.value.weightInFrom + " " 
    + this.ageGroupForm.value.weightInFromTime;

    this.ageGroupForm.value.weightInTo = this.ageGroupForm.value.weightInTo + " " 
    + this.ageGroupForm.value.weightInToTime;
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
