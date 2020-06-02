import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from '../config.service';
import { IProduct } from './product';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private configService: ConfigService, private oauthService: OAuthService) { }

  getProducts() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.oauthService.getAccessToken()
    });
    return this.http.get<IProduct[]>(this.configService.appConfig.product_list_url, {headers});
  }
}
