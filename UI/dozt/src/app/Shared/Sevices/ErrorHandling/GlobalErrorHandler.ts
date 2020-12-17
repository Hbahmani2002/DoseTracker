import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorService } from './ErrorService';
import { NotificationService } from './NotificationService';



@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private injector: Injector) { }

  handleError(error: Error | HttpErrorResponse) {

    const errorService = this.injector.get(ErrorService);
    const notifier = this.injector.get(NotificationService);

    let message;
    let stackTrace;
    if (error instanceof HttpErrorResponse) {
      // Server Error
      if (!navigator.onLine) {
        message = 'No Internet Connection';
      }
      else {
        message = errorService.getServerMessage(error);
      }
      
      stackTrace = errorService.getServerStack(error);
      notifier.showError(message,"Server Side");
    } else {
      // Client Error
      if (!navigator.onLine) {
        message = 'No Internet Connection';
      }
      else {
        message = errorService.getClientMessage(error);
      }
      stackTrace = errorService.getClientStack(error);
      notifier.showError(message,"Client Side");
    }

    // Always log errors
    //logger.logError(message, stackTrace);
    //console.error(error);
  }
}
