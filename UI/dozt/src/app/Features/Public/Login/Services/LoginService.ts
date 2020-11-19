// import { Injectable } from '@angular/core';
// import { httpService } from 'src/app/Shared/Services/Util/httpService';
// import { Observable, of, Subscription } from 'rxjs';
// import { tokenService } from 'src/app/Shared/Services/Util/tokenService';
// import { parameters } from 'src/app/Shared/Consts/parameters';
// import { map, catchError, switchMap } from 'rxjs/operators';
// import { apiResponseModel } from 'src/app/Shared/Services/Api/Models/apiResponseModel';

// export enum LoginEnumResult {
//   ok = 1,
//   fail = 0,
// }

// @Injectable({
//   providedIn: 'root'
// })
// export class LoginServices {

//   public serverAddress = parameters.serverAddress;
//   public serviceAdress: string = parameters.loginStatusServiceName;

//   constructor(private httpService: httpService, private tokenService: tokenService) { }

//   login(userName: string, password: string): Observable<any> {

//     let url = this.serverAddress + this.serviceAdress;
//     let params = {
//       userName: userName,
//       password: password
//     }
 
//     //TODO error handling--Internet connection check
//     return this.httpService.callPostService_Low(url, params, undefined).pipe(
//       switchMap(res => {
//         var data = apiResponseModel.parse(res);
//         if (res) {
//           let token = data.data;
//           this.tokenService.saveToken(token);
//         }
//         return of(LoginEnumResult.ok);
//       })
//       //result is success
//     );
//   }
// }
