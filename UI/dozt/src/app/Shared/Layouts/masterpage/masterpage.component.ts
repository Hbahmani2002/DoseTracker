import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-masterpage',
  templateUrl: './masterpage.component.html',
  styleUrls: ['./masterpage.component.css']
})
export class MasterpageComponent implements OnInit {
  public collapse: boolean = false;
  public collapse1: boolean = false;
  userName: string;
  constructor(
    // private logoutService: LogoutService, 
    // private modalService: BsModalService, 
    // private changeDetection: ChangeDetectorRef, 
    // private authservice: authenticationDataService
  ) { }

  ngOnInit() {
    //this.getUserInfo();
  }
  toggle() {
    if (this.collapse == true) {
      this.collapse = false;
    }
    else {
      this.collapse = true;
    }
  }
  toggleInSide() {
    if (!this.collapse) {
      this.toggle();
    }
  }
  getUserInfo() {
    // this.authservice.isLoggedIn(true).subscribe(info => {
    //   console.log(info);
    //   this.userName = info.userName;
    // });
  }
  logout() {
    // const initialState = {
    //   modalTitle: "Uyarı",
    //   message: "Sistemden çıkış yapmak istediğinize emin misiniz?",
    // };
    // this.modal.openModal(ConfirmationdialogComponent, initialState).subscribe((result) => {
    //   if (result.reason == 'ok') {
    //     console.log("logout");
    //     this.logoutService.logout();
    //   }
    // });
  }
}
