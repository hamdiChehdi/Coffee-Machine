import { DrinktypeService } from './drinktype.service';
import { of } from 'rxjs';
import { DrinkType } from '../models/DrinkType';

describe('DrinktypeService', () => {
  let service: DrinktypeService;
  let mockHttp;

  beforeEach(() => {
    mockHttp = jasmine.createSpyObj('mockHttp', ['get']);
    service = new DrinktypeService(mockHttp);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });


  it('should return drinktype list ', () => {
    const drinktypes: DrinkType[] = [
      {
        id: 1,
        name: 'Chocolate',
        imageUrl: 'images/chocolate.png',
        price: 2
      },
      {
        id: 2,
        name: 'Tea',
        imageUrl: 'images/Tea.png',
        price: 4
      }
    ];

    mockHttp.get.and.returnValue(of(drinktypes));

    service.getAllDrinktypes()
      .subscribe(data => {
        expect(data).toBe(drinktypes);
      });

  });

});
