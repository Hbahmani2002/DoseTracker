import { cookieService } from './cookieService';
import { Router } from '@angular/router';

export class LogoutService {
  constructor(private cookieService: cookieService, private routing: Router) {

  }

  private token: string;
  private authCookieName: string = 'gt_auth';

  private removeCookie() {
    this.token = undefined;
    this.cookieService.eraseCookie(this.authCookieName);
  }
  private redirectToLogin() {
    this.routing.navigate(["login"]);
  }
  public logout() {
    console.log("logout Service");
    this.removeCookie();
    this.redirectToLogin();
  }

}
