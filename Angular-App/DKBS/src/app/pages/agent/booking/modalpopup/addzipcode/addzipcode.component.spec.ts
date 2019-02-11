import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddzipcodeComponent } from './addzipcode.component';

describe('AddzipcodeComponent', () => {
  let component: AddzipcodeComponent;
  let fixture: ComponentFixture<AddzipcodeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddzipcodeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddzipcodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
