import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
        return  next.handle(req).pipe(
            catchError ( Error => {
                if (Error instanceof HttpErrorResponse) {
                      if (Error.status === 401 ) {
                          return throwError(Error.statusText);

                      }
                            const appError = Error.headers.get('Application-Error') ;
                            if ( appError) {
                                console.error(appError);

                                return throwError(appError);
                            }
                            const serverError = Error.error;
                            let modelStatesError = '';
                            if ( serverError && typeof serverError === 'object') {
                                for (const key in serverError) {
                                    if (serverError[key]) {
                                        modelStatesError += serverError[key] + '\n';
                                    }
                               }

                             }
                             return throwError( modelStatesError || serverError || 'server Error');

                }

            } )
            );
        }
    }
export const ErrorInterceptorProvider = {
        provide : HTTP_INTERCEPTORS ,
        useClass : ErrorInterceptor ,
        multi: true  };
