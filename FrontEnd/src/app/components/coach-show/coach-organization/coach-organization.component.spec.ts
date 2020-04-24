import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoachOrganizationComponent } from './coach-organization.component';

describe('CoachOrganizationComponent', () => {
  let component: CoachOrganizationComponent;
  let fixture: ComponentFixture<CoachOrganizationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoachOrganizationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoachOrganizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
