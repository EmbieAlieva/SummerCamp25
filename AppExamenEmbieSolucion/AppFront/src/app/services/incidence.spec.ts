import { TestBed } from '@angular/core/testing';

import { Incidence } from './incidence';

describe('Incidence', () => {
  let service: Incidence;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Incidence);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
