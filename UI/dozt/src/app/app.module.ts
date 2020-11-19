import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Features/Public/Login/Pages/login/login.component';
import { DashboardComponent } from './Features/Private/Dosetracking/Pages/dashboard/dashboard.component';
import { MasterpageComponent } from './Shared/Layouts/masterpage/masterpage.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PageheaderComponent } from './Shared/Components/pageheader/pageheader.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    MasterpageComponent,
    PageheaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
