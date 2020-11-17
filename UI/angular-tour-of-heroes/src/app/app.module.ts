import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChartsModule } from 'ng2-charts';
import { ChartModule } from 'angular2-highcharts';

import { LineChartComponent } from './line-chart/line-chart.component';
//import { FinancialChartComponent } from './financial-chart/financial-chart.component';
import { Chart2Component } from './chart2/chart2.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LineChartComponent,
    //FinancialChartComponent,
    Chart2Component
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
