import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AwaitingpartnersComponent } from './awaitingpartners.component';

describe('AwaitingpartnersComponent', () => {
  let component: AwaitingpartnersComponent;
  let fixture: ComponentFixture<AwaitingpartnersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AwaitingpartnersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AwaitingpartnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
