import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnernonpartnerComponent } from './partnernonpartner.component';

describe('PartnernonpartnerComponent', () => {
  let component: PartnernonpartnerComponent;
  let fixture: ComponentFixture<PartnernonpartnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartnernonpartnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnernonpartnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
