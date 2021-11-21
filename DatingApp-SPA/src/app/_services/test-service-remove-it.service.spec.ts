import { TestBed } from '@angular/core/testing';

import { TestServiceRemoveItService } from './test-service-remove-it.service';

describe('TestServiceRemoveItService', () => {
  let service: TestServiceRemoveItService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestServiceRemoveItService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
