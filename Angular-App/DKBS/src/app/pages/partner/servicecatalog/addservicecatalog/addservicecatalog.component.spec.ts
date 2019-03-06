import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddservicecatalogComponent } from './addservicecatalog.component';

describe('AddservicecatalogComponent', () => {
  let component: AddservicecatalogComponent;
  let fixture: ComponentFixture<AddservicecatalogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddservicecatalogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddservicecatalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
