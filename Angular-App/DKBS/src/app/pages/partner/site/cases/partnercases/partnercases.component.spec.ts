import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnercasesComponent } from './partnercases.component';

describe('PartnercasesComponent', () => {
  let component: PartnercasesComponent;
  let fixture: ComponentFixture<PartnercasesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartnercasesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnercasesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
