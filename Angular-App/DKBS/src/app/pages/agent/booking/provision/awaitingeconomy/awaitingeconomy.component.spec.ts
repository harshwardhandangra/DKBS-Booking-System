import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AwaitingeconomyComponent } from './awaitingeconomy.component';

describe('AwaitingeconomyComponent', () => {
  let component: AwaitingeconomyComponent;
  let fixture: ComponentFixture<AwaitingeconomyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AwaitingeconomyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AwaitingeconomyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
