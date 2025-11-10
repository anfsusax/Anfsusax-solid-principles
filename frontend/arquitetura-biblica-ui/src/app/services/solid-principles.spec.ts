import { TestBed } from '@angular/core/testing';

import { SolidPrinciples } from './solid-principles';

describe('SolidPrinciples', () => {
  let service: SolidPrinciples;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SolidPrinciples);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
