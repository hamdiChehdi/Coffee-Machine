import { Component, Output, EventEmitter } from '@angular/core';
import { BadgeService } from 'src/app/services/badge.service';

@Component({
  selector: 'app-badge',
  templateUrl: './badge.component.html',
  styleUrls: ['./badge.component.css']
})
export class BadgeComponent {

  constructor(private badgeService: BadgeService) { }

  @Output() onwerChange = new EventEmitter();
  badgeNumber: string;
  owner: string;

  checkBadge() {
    this.badgeService.getOwner(this.badgeNumber)
      .subscribe((data: string) => {
        this.owner = data;

        if (this.owner !== '') {
          this.onwerChange.emit(this.badgeNumber);
        }
        else {
          this.onwerChange.emit('');
        }
      },
        error => {
          this.onwerChange.emit('');
          this.owner = ''; });
  }
}
