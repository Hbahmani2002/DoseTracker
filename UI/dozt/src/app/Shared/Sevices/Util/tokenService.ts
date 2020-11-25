import { Injectable } from '@angular/core';
import { parameters } from '../../Consts/parameters';
import { cookieService } from '../Util/cookieService';

@Injectable({
  providedIn: 'root'
})
export class tokenService {
  cookieName = parameters.cookieName;
  cookieDay = parameters.cookieDay;
  tokenValue: string = undefined;
  constructor(private cookieService: cookieService) {
    let value = this.getTokenFromCookie();
    if (!value)
      return undefined;
    this.tokenValue = value;
  }
  private saveTokenCookie(tokenValue: string) {
   this.cookieService.setCookie(this.cookieName, tokenValue, this.cookieDay);
  }
  public saveToken(tokenValue: string) {
    this.saveTokenCookie(tokenValue);
    let value = this.getTokenFromCookie();
    if (!value)
      throw "Token Cookie değeri okunamadı";
    this.tokenValue = value;
  }
  private getTokenFromCookie() {
    let val = this.cookieService.getCookie(this.cookieName);
    return val;    
  }
  public getToken(): string {
    return this.tokenValue;
  }
}
