import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { map, catchError, switchMap } from 'rxjs/operators';
import { Observable, of, Subscription } from 'rxjs';
import { Injectable } from '@angular/core';
import { authenticationDataService } from '../Data/authenticationDataService';

@Injectable()
export class LoginCheckActivate implements CanActivate {
  route: ActivatedRouteSnapshot;
  state: RouterStateSnapshot;
  constructor(private authDataService: authenticationDataService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {

    this.route = route;
    this.state = state;
    console.log("GuardCheck Path:" + this.route.routeConfig.path)

    return this.authDataService.isLoggedIn().pipe(
      switchMap((res) => {
        if (res != true) {
          let r = this.fail();
          return of(r)
        }
        let r = this.success();
        return of(r);
      })
    )
  }
  success() {
    if (this.route.routeConfig.path != "login") {
      console.log("Giriş yapılmış, sayfaya yönlendir");
      return true;
    }
    console.log("Giriş yapılmış, login sayfasına gidemez");
    this.router.navigate(['']);
    return false;
  }
  fail(): boolean {
    console.log("Giriş yapılmamış, login sayfasına gider");
    if (this.route.routeConfig.path == "login") {
      return true;
    }
    this.router.navigate(['login']);
    return false;
  }
  redirectToLogin() {
    console.warn("Redirected to LOGIN");

  }
}
