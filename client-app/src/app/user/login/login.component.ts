import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { NgForm } from '@angular/forms';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userName: string;

  constructor(private authService: AuthService, private oauthService: OAuthService, private router: Router) { }

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['product']);
    }
  }

  login(loginForm: NgForm) {
    // console.log(loginForm);
    if (loginForm.valid) {
      this.authService.login(loginForm.value.userName);
    }
  }

  getProduct() {
    this.authService.testLogin().subscribe(resp => {
      console.log('resp');
    });
  }

  cancel() {
    // if (this.authService.getRedirectUrl()) {
    //   this.router.navigate([this.authService.getRedirectUrl()]);
    // } else{
    this.router.navigate(['home']);
    // }
  }

}
