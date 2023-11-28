import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TableService } from './table.service';
import { Router } from '@angular/router';
import { DynamicActionHistory } from 'src/shared/models/dynamic-action';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  public data$: Observable<DynamicActionHistory[]>;
  public show: boolean = false;
  @Input() reload$: EventEmitter<number> = new EventEmitter<number>();

  constructor(public service: TableService,
    private router: Router) {
    this.data$ = service.data$;
    
  }
  ngOnInit(): void {
    this.reload$.subscribe(dynamicActionId=>{
      this.service.dynamicActionId = dynamicActionId;
      this.show = true;
      this.service.refresh();
    })
  }

}
