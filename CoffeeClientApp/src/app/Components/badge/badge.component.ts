import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BadgeService } from 'src/app/services/badge.service';

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
    .subscribe((data: string) => {
      this.owner = data;
      console.log(data);

      if (this.owner !== ''){
        this.onwerChange.emit(this.badgeNumber);
      }
    });
  }
}
