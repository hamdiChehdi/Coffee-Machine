import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { DrinkType } from 'src/app/models/DrinkType';
import { DrinktypeService } from 'src/app/services/drinktype.service';

@Component({
  selector: 'app-select-drink-type',
  templateUrl: './select-drink-type.component.html',
  styleUrls: ['./select-drink-type.component.css']
})
export class SelectDrinkTypeComponent implements OnInit {

  constructor(private drinkTypeService: DrinktypeService) { }

  drinkTypes: DrinkType[];
  selectedDrinkType: DrinkType;
  @Output() drinkTypeChange = new EventEmitter();

  private drinkTypeId: number;

  // use getter setter to define the property
  get selectedDrinkTypeId(): number {
    return this.drinkTypeId;
  }

  @Input()
  set selectedDrinkTypeId(val: number) {
    this.drinkTypeId = val;

    if (this.drinkTypes) {
      this.selectedDrinkType = this.drinkTypes.find(d => d.id === this.selectedDrinkTypeId);
    }
  }


  ngOnInit(): void {
    this.drinkTypeService.getAllDrinktypes()
      .subscribe((data: DrinkType[]) => {
        this.drinkTypes = data;
        this.selectedDrinkType = this.drinkTypes.find(d => d.id === this.selectedDrinkTypeId);
        console.log(data);
      });

  }

  changeSelected(element: DrinkType) {
    this.selectedDrinkType = element;
    this.drinkTypeChange.emit(this.selectedDrinkType.id);
  }
}
