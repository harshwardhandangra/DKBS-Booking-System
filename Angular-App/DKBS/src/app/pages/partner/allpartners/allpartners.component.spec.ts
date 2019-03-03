import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllPartnersComponent } from './allpartners.component';

describe('AllPartnersComponent', () => {
  let component: AllPartnersComponent;
  let fixture: ComponentFixture<AllPartnersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllPartnersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllPartnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
