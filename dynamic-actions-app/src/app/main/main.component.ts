import { Component, EventEmitter, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { LoaderService } from 'src/shared/loader.service';
import { ActionsService } from 'src/shared/actions.service';
import { TableService } from '../table/table.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  public reload$: EventEmitter<number> = new EventEmitter<number>();
  public reloadTable$: EventEmitter<number> = new EventEmitter<number>();
  constructor() {
    this.reload$.subscribe(dynamicActionId => {
      this.reloadTable$.emit(dynamicActionId);
    })
  }
}
