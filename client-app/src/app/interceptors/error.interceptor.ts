import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ConfigService } from '../config.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private configService: ConfigService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.indexOf('assets') > -1) {
            return next.handle(req);
        }

        return next.handle(req).pipe(catchError(err => {
            console.log(req);
            console.log(err);
            if (err instanceof HttpErrorResponse) {
                // if (err.status == 400
                //     || err.status == 401
                //     || err.status == 403
                //     || err.status == 416
                //     || err.status == 419) {
                //     return Observable.throw(err);
                // }

                const errorMessage = 'errors.' + (err.error.errorCode || 'unknown');
                return throwError(new Error(errorMessage));
            }
            return throwError(err);
        }));
    }

}
