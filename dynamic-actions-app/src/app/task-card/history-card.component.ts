import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DynamicActionHistory } from 'src/shared/models/dynamic-action';

@Component({
  selector: 'history-card',
  templateUrl: './history-card.component.html',
  styleUrls: ['./history-card.component.css']
})
export class HistoryCardComponent {

  @Input() task?: DynamicActionHistory;

  constructor(
    private router: Router,
  ) {
  }


}
