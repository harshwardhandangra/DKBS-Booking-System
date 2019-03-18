import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CouserpackagepriceComponent } from './couserpackageprice.component';

describe('CouserpackagepriceComponent', () => {
  let component: CouserpackagepriceComponent;
  let fixture: ComponentFixture<CouserpackagepriceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CouserpackagepriceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CouserpackagepriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
