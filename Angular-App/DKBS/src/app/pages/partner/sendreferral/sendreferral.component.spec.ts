import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SendreferralComponent } from './sendreferral.component';

describe('SendreferralComponent', () => {
  let component: SendreferralComponent;
  let fixture: ComponentFixture<SendreferralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SendreferralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SendreferralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
