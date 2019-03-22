import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnernavigationComponent } from './partnernavigation.component';

describe('PartnernavigationComponent', () => {
  let component: PartnernavigationComponent;
  let fixture: ComponentFixture<PartnernavigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartnernavigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnernavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
