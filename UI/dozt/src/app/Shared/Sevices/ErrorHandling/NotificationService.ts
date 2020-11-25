import { Injectable } from '@angular/core';
// import { ToastrService } from 'ngx-toastr';
//import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    // private toastr: ToastrService
  ) { }

  showSuccess(message: string, type: string): void {
    console.log("Success from " + type + " : " + message);
    // this.toastr.success("Success from " + type + " : " + message);
  }
  showError(message: string, type: string): void {
    console.log("Faild from "+ type +" : " + message);
    // this.toastr.error("Faild from " + type + " : " + message);
  }
}
