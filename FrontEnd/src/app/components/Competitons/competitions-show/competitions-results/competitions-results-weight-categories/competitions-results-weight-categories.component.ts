import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { WeightCategoryService } from '../../../../../../services/weight-category.service';
import { AgeGroupService } from '../../../../../../services/age-group.service';
import { WeightCategory } from '../../../../../../data/weight-category.data';

@Component({
  selector: 'app-competitions-results-weight-categories',
  templateUrl: './competitions-results-weight-categories.component.html',
  styleUrls: ['./competitions-results-weight-categories.component.css']
})
export class CompetitionsResultsWeightCategoriesComponent implements OnInit {

  catLinks: any[] = [];
  activeLinkIndex = -1;

  ageGroupId: number;
  routeSub: any;

  weightCategories: WeightCategory[];
  errorMessage: string;

  constructor(private ageGroupService: AgeGroupService, private router: Router, private route: ActivatedRoute, private titleService: Title) { 

    this.routeSub = this.route.params.subscribe(params => {
      this.ageGroupId = params['groupId'] as number;
      this.getWeightCategories();
    });

  }
  ngOnInit() {
    
  }

  private getWeightCategories() {
    this.catLinks = [];
    return this.ageGroupService.getWeightCategories(this.ageGroupId)
      .subscribe(
        data => {
          this.weightCategories = data as WeightCategory[];
          let i = 0;
          this.weightCategories.forEach(element => {
            this.catLinks.push({label: element.title, link: './weight-category/' + element.id, index: i}) 
          });
          i = i + 1;
        },
        error => {
          this.errorMessage = error["error"].message;
          console.log(error); //gives an object at this point
        }
      );
  }

  private appendTitle(name) {
    this.titleService.setTitle( "Results - " +  name);
  }

}