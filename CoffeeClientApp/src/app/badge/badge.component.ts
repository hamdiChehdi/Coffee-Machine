import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BadgeService } from '../services/badge.service';

@Component({
  selector: 'app-badge',
  templateUrl: './badge.component.html',
  styleUrls: ['./badge.component.css']
})
export class BadgeComponent implements OnInit {

  constructor(private badgeService: BadgeService) { }

  @Output() onwerChange = new EventEmitter();
  badgeNumber: string;
  owner: string;

  ngOnInit(): void {
  }

  checkBadge() {
    this.badgeService.getOwner(this.badgeNumber)
    .subscribe(data => {
      this.owner = data as string;
      console.log(data);

      if (this.owner !== ''){
        this.onwerChange.emit(this.badgeNumber);
      }
    });
  }
}
