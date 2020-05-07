import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionsShowComponent } from './competitions-show.component';

describe('CompetitionsShowComponent', () => {
  let component: CompetitionsShowComponent;
  let fixture: ComponentFixture<CompetitionsShowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionsShowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionsShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
