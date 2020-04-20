import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { environment } from './../environments/environment';
import { Observable, ObservableInput, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { IAppConfig } from './config';

@Injectable({
    providedIn: 'root'
})
export class AppInitializer {

    constructor(private http: HttpClient, private config: ConfigService, private injector: Injector) { }

    load(): (Promise<boolean>) {
        return new Promise<boolean>((resolve: (a: boolean) => void): void => {
            this.http.get(environment.appConfigUrl)
                .pipe(
                    map((x: IAppConfig) => {
                        this.config.appConfig = x;
                        resolve(true);
                    }),
                    catchError((x: { status: number }, caught: Observable<void>): ObservableInput<{}> => {
                        const router = this.injector.get(Router);
                        router.navigate(['/error']);
                        resolve(false);
                        return of({});
                    })
                ).subscribe();
        });
    }
}
