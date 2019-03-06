import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnerlistsiteComponent } from './partnerlistsite.component';

describe('PartnerlistsiteComponent', () => {
  let component: PartnerlistsiteComponent;
  let fixture: ComponentFixture<PartnerlistsiteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartnerlistsiteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnerlistsiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
