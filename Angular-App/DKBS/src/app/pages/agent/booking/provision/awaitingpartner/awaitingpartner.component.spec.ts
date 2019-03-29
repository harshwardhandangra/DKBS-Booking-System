import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AwaitingpartnerComponent } from './awaitingpartner.component';

describe('AwaitingpartnerComponent', () => {
  let component: AwaitingpartnerComponent;
  let fixture: ComponentFixture<AwaitingpartnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AwaitingpartnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AwaitingpartnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
