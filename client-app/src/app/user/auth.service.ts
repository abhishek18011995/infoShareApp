import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from '../config.service';
import { Observable } from 'rxjs';
import { IAppConfig } from '../config';
import { IUser } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private configService: ConfigService) { }

  login(userName: string): Observable<IAppConfig> {
    let headers = new HttpHeaders();
    headers = headers.append('content-type', 'application/json');
    return this.http.post<IAppConfig>(this.configService.appConfig.loginUrl, { userName }, {headers});
  }

  testLogin() {
    return this.http.get(this.configService.appConfig.loginUrl);
  }
}
