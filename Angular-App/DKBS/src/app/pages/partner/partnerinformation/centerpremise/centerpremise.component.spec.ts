import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenterpremiseComponent } from './centerpremise.component';

describe('CenterpremiseComponent', () => {
  let component: CenterpremiseComponent;
  let fixture: ComponentFixture<CenterpremiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenterpremiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenterpremiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
