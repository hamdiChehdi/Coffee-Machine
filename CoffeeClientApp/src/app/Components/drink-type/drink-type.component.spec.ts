import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrinkTypeComponent } from './drink-type.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { DrinkType } from '../../models/DrinkType';

describe('DrinkTypeComponent', () => {
  let component: DrinkTypeComponent;
  let fixture: ComponentFixture<DrinkTypeComponent>;
  let drinktype: DrinkType;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ DrinkTypeComponent ]
    })
    .compileComponents();

    drinktype = {
      id: 1,
      name: 'Chocolate',
      imageUrl: 'images/chocolate.png',
      price: 2
    };
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrinkTypeComponent);

    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
