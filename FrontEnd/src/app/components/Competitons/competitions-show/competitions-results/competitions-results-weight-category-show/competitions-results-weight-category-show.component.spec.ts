import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionsResultsWeightCategoryShowComponent } from './competitions-results-weight-category-show.component';

describe('CompetitionsResultsWeightCategoryShowComponent', () => {
  let component: CompetitionsResultsWeightCategoryShowComponent;
  let fixture: ComponentFixture<CompetitionsResultsWeightCategoryShowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionsResultsWeightCategoryShowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionsResultsWeightCategoryShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
