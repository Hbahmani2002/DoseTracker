import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './Features/Private/Dosetracking/Pages/dashboard/dashboard.component';
import { LoginComponent } from './Features/Public/Login/Pages/login/login.component';
import { MasterpageComponent } from './Shared/Layouts/masterpage/masterpage.component';

const routes: Routes = [
  {
    path: '',
    component: MasterpageComponent,
    //canActivate: [true],
    children: [
      { path: '', component: DashboardComponent, pathMatch: 'full' }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  }
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
