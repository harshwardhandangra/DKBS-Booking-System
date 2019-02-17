import { TestBed } from '@angular/core/testing';

import { StateprovinanceService } from './stateprovinance.service';

describe('StateprovinanceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StateprovinanceService = TestBed.get(StateprovinanceService);
    expect(service).toBeTruthy();
  });
});
