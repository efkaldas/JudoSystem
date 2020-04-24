import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewAgeGroupComponent } from './new-age-group.component';

describe('NewAgeGroupComponent', () => {
  let component: NewAgeGroupComponent;
  let fixture: ComponentFixture<NewAgeGroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewAgeGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewAgeGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
