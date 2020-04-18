import { TestBed } from '@angular/core/testing';

import { BadgeService } from './badge.service';
import { of } from 'rxjs';

describe('BadgeService', () => {
  let service: BadgeService;
  let mockHttp;

  beforeEach(() => {
    mockHttp = jasmine.createSpyObj('mockHttp', ['get']);
    service = new BadgeService(mockHttp);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return owner', () => {
    mockHttp.get.and.returnValue(of('john'));
    service.getOwner('XA74DE')
    .subscribe(data => {
      expect(data).toBe('john');
    });

  });
});
