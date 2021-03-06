import { Component } from '@angular/core';
import { ClientSelectionService } from './services/client-selection.service';
import { ClientSelection } from './models/ClientSelection';
import { MatDialog } from '@angular/material/dialog';
import { DisplayValidationComponent } from './Components/display-validation/display-validation.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent  {
  constructor(private clientSelectionService: ClientSelectionService,
              public dialog: MatDialog) {
    this.setDefaultFieldsValue();
    this.disableBuy = true;
  }

  selectedDrinkTypeId: number;
  sugarQty: number;
  useOwnerMug: boolean;
  badgeNumber: string;

  updateSelection: boolean;
  disableBuy: boolean;

  updateBadgeNumber(badgeNumber: string) {
    if (badgeNumber === '') {
      this.disableBuy = true;
      this.setDefaultFieldsValue();
      return;
    }

    this.disableBuy = false;
    this.badgeNumber = badgeNumber;
    this.setDefaultFieldsValue();

    this.clientSelectionService.getClientSelection(this.badgeNumber)
    .subscribe(data => {
      this.setClientSelectionFields(data as ClientSelection);
      this.updateSelection = true;
    },
    error => console.log('no previous selection from this client'));
  }

  saveSelection()
  {
    const clientSelection = this.getClientSelectionFromFields();

    if (!this.updateSelection) {
      this.clientSelectionService.SaveClientSelection(clientSelection)
        .subscribe(data => {
          this.DisplayValidation();
      });
    }
    else {
      this.clientSelectionService.UpdateClientSelection(clientSelection)
      .subscribe(data => {
        this.DisplayValidation();
     });
    }
  }

  DisplayValidation(): void {
    this.dialog.open(DisplayValidationComponent, {
      width: '340px',
      height: '420px'
    });
  }

  drinkTypeChange(id: number) {
    this.selectedDrinkTypeId = id;
  }

  setClientSelectionFields(clientSelection: ClientSelection) {
      this.selectedDrinkTypeId = clientSelection.drinkTypeId;
      this.useOwnerMug = clientSelection.usePersonalMug;
      this.sugarQty = clientSelection.sugarQty;
  }

  getClientSelectionFromFields(): ClientSelection {
    const clientSelection = new ClientSelection();
    clientSelection.badgeNumber = this.badgeNumber;
    clientSelection.drinkTypeId = this.selectedDrinkTypeId;
    clientSelection.usePersonalMug = this.useOwnerMug;
    clientSelection.sugarQty = Number(this.sugarQty);
    return clientSelection;
  }

  setDefaultFieldsValue() {
    this.sugarQty = 0;
    this.useOwnerMug = false;
    this.updateSelection = false;
    this.selectedDrinkTypeId = 0;
  }

}
