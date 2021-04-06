import { TestBed } from '@angular/core/testing';

import { Http.CrudService } from './http.crud.service';

describe('Http.CrudService', () => {
  let service: Http.CrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Http.CrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
