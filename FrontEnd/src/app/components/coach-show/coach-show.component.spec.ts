import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoachShowComponent } from './coach-show.component';

describe('CoachShowComponent', () => {
  let component: CoachShowComponent;
  let fixture: ComponentFixture<CoachShowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoachShowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoachShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
