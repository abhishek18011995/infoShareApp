import { Component, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler, LoginOptions } from 'angular-oauth2-oidc';
import { authConfig } from './user/auth.config';
import { AuthService } from './user/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client-app';

  constructor(private oauthService: OAuthService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.initIdpLogin();
  }

  initIdpLogin() {
    console.log(this.oauthService.getIdentityClaims());
    if (!this.authService.isAuthenticated()) {
      this.oauthService.configure(authConfig);
      this.oauthService.loadDiscoveryDocumentAndTryLogin();
      this.oauthService.events.subscribe(event => {
        if (event.type === 'token_received') {
          this.authService.setUserDetails(this.oauthService.getIdentityClaims());
          this.router.navigate(['home']);
        }

        if (event.type === 'token_error') {
          // this.router.navigate(['error']);
        }

        if (event.type === 'token_validation_error') {
          // this.router.navigate(['error']);
        }
      });
    }
    console.log('Access-Token : ' + this.oauthService.hasValidAccessToken());
    console.log('Id-Token : ' + this.oauthService.hasValidIdToken());
  }

}
