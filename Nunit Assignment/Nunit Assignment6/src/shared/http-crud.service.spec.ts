import { TestBed } from '@angular/core/testing';

import { HttpCRUDService } from './http-crud.service';

describe('HttpCRUDService', () => {
  let service: HttpCRUDService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpCRUDService);
  });


});
