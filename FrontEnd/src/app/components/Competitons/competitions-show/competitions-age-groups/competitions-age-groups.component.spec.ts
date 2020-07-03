import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionsAgeGroupsComponent } from './competitions-age-groups.component';

describe('CompetitionsAgeGroupsComponent', () => {
  let component: CompetitionsAgeGroupsComponent;
  let fixture: ComponentFixture<CompetitionsAgeGroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionsAgeGroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionsAgeGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
