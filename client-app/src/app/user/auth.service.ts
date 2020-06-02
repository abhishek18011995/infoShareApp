import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from '../config.service';
import { Observable } from 'rxjs';
import { IAppConfig } from '../config';
import { IUser } from './user';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userDetails;
  private redirectUrl: string;

  constructor(private http: HttpClient, private configService: ConfigService, private oauthService: OAuthService) { }

  // login(userName: string): Observable<IAppConfig> {
  //   let headers = new HttpHeaders();
  //   headers = headers.append('content-type', 'application/json');
  //   return this.http.post<IAppConfig>(this.configService.appConfig.loginUrl, { userName }, {headers});
  // }

  login(userName) {
    if (!this.oauthService.hasValidIdToken()) {
      this.oauthService.initCodeFlow('', { login_hint: userName });
    }
  }

  logout() {
    this.oauthService.logOut();
  }

  isAuthenticated(): boolean {
    return this.oauthService.hasValidIdToken();
  }

  setUserDetails(userDetails) {
    this.userDetails = userDetails;
  }

  getUserDetails() {
    return this.userDetails;
  }

  setRedirectUrl(redirectUrl: string) {
    this.redirectUrl = redirectUrl;
  }

  getRedirectUrl() {
    return this.redirectUrl;
  }

  testLogin() {
    return this.http.get(this.configService.appConfig.loginUrl);
  }
}
