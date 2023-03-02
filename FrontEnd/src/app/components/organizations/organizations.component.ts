import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { OrganizationService } from '../../services/organization.service';
import { MatDialog, MatSnackBar, MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { Organization } from '../../data/organization.data';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-organizations',
  templateUrl: './organizations.component.html',
  styleUrls: ['./organizations.component.css']
})
export class OrganizationsComponent implements OnInit {

  selectedElement: Organization;
  organizations: Organization[];
  public organizationForm: FormGroup;

  dataSource = new MatTableDataSource;
  source : MatTableDataSource<Organization>;
  displayedColumns: string[] = ['position', 'exactName', 'shortName', 'country', 'address', 'type', 'actions'];
  errorMessage: string;

  constructor(private organizationService: OrganizationService, public dialog: MatDialog, private _snackBar: MatSnackBar,
    private fb: FormBuilder) { }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.getOrganizations();
  }

    private formGroup()
  {
    this.organizationForm = this.fb.group({
      id: this.selectedElement.id,
      exactName: this.selectedElement.exactName,
      shortName: [null, Validators.compose([Validators.required])],
      country: this.selectedElement.country,
      city: this.selectedElement.city,
      address: this.selectedElement.address,
      image: this.selectedElement.address,
      type: this.selectedElement.type,
    });
  }
  public update()
  {
    if(this.organizationForm.valid)    
    {
    return this.organizationService.update(this.organizationForm.value.id, this.organizationForm.value)
      .subscribe(
        data => {
          this.openSnackBar("Organization has beed udated", 'CLOSE');
          this.getOrganizations();
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

  public openDialog(templateRef: TemplateRef<any>, element: Organization) {
    this.selectedElement = element;
    this.formGroup();
    this.dialog.open(templateRef);
  }
  public onNoClick(){
    this.selectedElement = null;
    this.dialog.closeAll()
  }
  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 4000,
      verticalPosition: 'top',
   //   horizontalPosition: 'end',
    });
  }

  private getOrganizations() {
    return this.organizationService.getAll()
      .subscribe(
        data => {
          this.organizations = data as Organization[];
          this.dataSource = new MatTableDataSource(this.organizations);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  

}
