import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionsTabsComponent } from './competitions-tabs.component';

describe('CompetitionsTabsComponent', () => {
  let component: CompetitionsTabsComponent;
  let fixture: ComponentFixture<CompetitionsTabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionsTabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionsTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
