import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenterinnumbersComponent } from './centerinnumbers.component';

describe('CenterinnumbersComponent', () => {
  let component: CenterinnumbersComponent;
  let fixture: ComponentFixture<CenterinnumbersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenterinnumbersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenterinnumbersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
