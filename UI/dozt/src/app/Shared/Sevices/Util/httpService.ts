import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
//import { CookieService } from 'ngx-cookie-service';
//import { ToastrService } from 'ngx-toastr';
import { map, catchError, switchMap } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
//import { FileService } from './file.service';
//import { environment } from './../shared/consts/environment';
//import { NotificationToastService } from '../Shared/services/notification-toast.service';
import { Router } from '@angular/router';
import { parameters } from '../../Consts/parameters';
//import { cookieService } from '../shared/services/cookieService';
//import { authenticationService } from '../shared/services/authenticationService';


@Injectable({
  providedIn: 'root'
})
export class httpService {

  constructor(private http: HttpClient) {}

  public callGetService_Low(url: string, token: string): Observable<any> {
    /*
     ##validation
    headeroptions
    */
    /*const httpOptions = {      
      headers: new HttpHeaders({
        //'Content-Type': 'application/json',
        //'Accept': 'application/octet-stream',
        "Authorization": 'Bearer ' + token,
      }),            
      responseType: 'blob' as 'blob',
    };*/
    return this.http.get(url);
  }
  public callPostService_Low(url: string, params: any, httpOptions: any = undefined): Observable<any> {
    /*
     ##validation
    headeroptions
    */
    return this.http.post(url, params, httpOptions);

  }
  public callPostService_Middle(url: string, params: any, token: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': 'application/json',
        "Authorization": 'Bearer ' + token
      })
    };
    return this.callPostService_Low(url, params, httpOptions);
  }
}
