import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenterdescriptionComponent } from './centerdescription.component';

describe('CenterdescriptionComponent', () => {
  let component: CenterdescriptionComponent;
  let fixture: ComponentFixture<CenterdescriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenterdescriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenterdescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
