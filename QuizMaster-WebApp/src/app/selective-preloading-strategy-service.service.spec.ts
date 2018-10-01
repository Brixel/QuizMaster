import { TestBed } from '@angular/core/testing';

import { SelectivePreloadingStrategyServiceService } from './selective-preloading-strategy-service.service';

describe('SelectivePreloadingStrategyServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SelectivePreloadingStrategyServiceService = TestBed.get(SelectivePreloadingStrategyServiceService);
    expect(service).toBeTruthy();
  });
});
