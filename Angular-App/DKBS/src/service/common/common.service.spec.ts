import { TestBed } from '@angular/core/testing';

import { CommonService } from "./Common.Service";

describe('CommonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CommonService = TestBed.get(CommonService);
    expect(service).toBeTruthy();
  });
});
