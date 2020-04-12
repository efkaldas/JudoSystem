import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaitingForApprovementComponent } from './waiting-for-approvement.component';

describe('WaitingForApprovementComponent', () => {
  let component: WaitingForApprovementComponent;
  let fixture: ComponentFixture<WaitingForApprovementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaitingForApprovementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaitingForApprovementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
