import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Features/Public/Login/Pages/login/login.component';
import { DashboardComponent } from './Features/Private/Dosetracking/Pages/dashboard/dashboard.component';
import { MasterpageComponent } from './Shared/Layouts/masterpage/masterpage.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PageheaderComponent } from './Shared/Components/pageheader/pageheader.component';
import { FilterComponent } from './Shared/Components/filter/filter.component';
import { ChartComponent } from './Features/Private/Dosetracking/Components/chart/chart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    MasterpageComponent,
    PageheaderComponent,
    FilterComponent,
    ChartComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
