import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule, NgbPaginationModule, NgbToastModule, NgbTooltipModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TruncatePipe } from 'src/shared/pipes/truncate.pipe';
import { SpinnerComponent } from './spinner/spinner.component';
import { DatePipe } from '@angular/common';
import { CalculateComponent } from './calculate/calculate.component';
import { MainComponent } from './main/main.component';
import { TableComponent } from './table/table.component';
import { HistoryCardComponent } from './task-card/history-card.component';

@NgModule({
  declarations: [
    AppComponent,
    TruncatePipe,
    SpinnerComponent,
    CalculateComponent,
    MainComponent,
    TableComponent,
    HistoryCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    NgbTypeaheadModule,
    NgbPaginationModule,
    NgbTooltipModule,
    ReactiveFormsModule,
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
