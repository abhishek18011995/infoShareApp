import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ConfigService } from '../config.service';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private configService: ConfigService, private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.indexOf('assets') > -1) {
            return next.handle(req);
        }

        return next.handle(req).pipe(catchError(err => {
            // console.log(req);
            // console.log(err);
            if (err instanceof HttpErrorResponse) {
                // if (err.status == 400
                //     || err.status == 401
                //     || err.status == 403
                //     || err.status == 416
                //     || err.status == 419) {
                //     return Observable.throw(err);
                // }

                if (err.url.indexOf('/token') > -1) {
                    // this.router.navigate(['error']);
                }
            }
            return throwError(err);
        }));
    }

}
