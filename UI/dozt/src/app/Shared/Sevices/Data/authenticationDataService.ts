import { ApiDataService } from '../Api/apiDataService';
import { map, catchError, switchMap } from 'rxjs/operators';
import { Observable, of, Subscription } from 'rxjs';
import { apiResponseModel } from '../Api/Models/apiResponseModel';
export class authenticationDataService {
  constructor(private apiDataService: ApiDataService) {

  }
  public isLoggedIn(forUserNeame?: boolean) {
    if (forUserNeame == true) {
      return this.getPermission().pipe(
        switchMap(res => {
          return of(res);
        }),
        catchError(err => {
          return of(undefined);
        })
      );
    }
    return this.getPermission().pipe(
      switchMap(res => {
        return of(true);
      })
      ,
      catchError(err => {
        return of(false);
      })
      //result is success
    );
  }

  // TODO: add Global error handling function 
  public getPermission(): Observable<boolean> {
    return this.apiDataService.callDataService('Authentication/GetPermission', undefined)
  }
  public GetUser(): Observable<string> {
    return this.apiDataService.callDataService('Authentication/GetUser', undefined);
  }
}
