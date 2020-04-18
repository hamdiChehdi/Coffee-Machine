import { ClientSelectionService } from './client-selection.service';
import { ClientSelection } from '../models/ClientSelection';
import { of } from 'rxjs';

describe('ClientSelectionService', () => {
  let service: ClientSelectionService;
  let mockHttp;

  beforeEach(() => {
    mockHttp = jasmine.createSpyObj('mockHttp', ['get']);
    service = new ClientSelectionService(mockHttp);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return client selection ', () => {
    const clientSelection: ClientSelection =
      {
        badgeNumber: 'XAERJ7',
        usePersonalMug: true,
        drinkTypeId: 1,
        sugarQty: 40
      };

    mockHttp.get.and.returnValue(of(clientSelection));

    service.getClientSelection('XAERJ7')
      .subscribe(data => {
        expect(data).toBe(clientSelection);
      });

  });
});
