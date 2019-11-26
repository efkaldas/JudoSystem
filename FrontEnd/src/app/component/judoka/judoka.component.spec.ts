import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JudokaComponent } from './judoka.component';

describe('JudokaComponent', () => {
  let component: JudokaComponent;
  let fixture: ComponentFixture<JudokaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JudokaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JudokaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
