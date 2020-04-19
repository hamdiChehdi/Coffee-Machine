import { Component, Input} from '@angular/core';
import { DrinkType } from 'src/app/models/DrinkType';


@Component({
  selector: 'app-drink-type',
  templateUrl: './drink-type.component.html',
  styleUrls: ['./drink-type.component.css']
})

export class DrinkTypeComponent {

  constructor() { }

  @Input() drinkType: DrinkType;

}
