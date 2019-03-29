import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AwaitingDKBSComponent } from './awaiting-dkbs.component';

describe('AwaitingDKBSComponent', () => {
  let component: AwaitingDKBSComponent;
  let fixture: ComponentFixture<AwaitingDKBSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AwaitingDKBSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AwaitingDKBSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
