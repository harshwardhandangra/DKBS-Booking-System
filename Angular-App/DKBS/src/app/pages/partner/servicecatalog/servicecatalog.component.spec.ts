import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicecatalogComponent } from './servicecatalog.component';

describe('ServicecatalogComponent', () => {
  let component: ServicecatalogComponent;
  let fixture: ComponentFixture<ServicecatalogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ServicecatalogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicecatalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
