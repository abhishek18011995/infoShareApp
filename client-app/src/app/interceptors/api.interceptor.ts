import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from '../config.service';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

    constructor(private configService: ConfigService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.indexOf('assets') < 0) {
            req = req.clone({ url: `${this.configService.appConfig.apiUrl}${req.url}` });
        }

        return next.handle(req);
    }

}
