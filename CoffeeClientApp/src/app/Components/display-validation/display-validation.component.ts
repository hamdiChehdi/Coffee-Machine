import { Component } from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';

@Component({
  templateUrl: './display-validation.component.html',
  styleUrls: ['./display-validation.component.css']
})
export class DisplayValidationComponent  {

  constructor(
    public dialogRef: MatDialogRef<DisplayValidationComponent>) {}

}
