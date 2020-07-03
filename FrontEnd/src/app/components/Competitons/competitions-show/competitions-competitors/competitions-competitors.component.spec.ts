import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionsCompetitorsComponent } from './competitions-competitors.component';

describe('CompetitionsCompetitorsComponent', () => {
  let component: CompetitionsCompetitorsComponent;
  let fixture: ComponentFixture<CompetitionsCompetitorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionsCompetitorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionsCompetitorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
