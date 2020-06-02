import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_BASE_HREF } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';

import { OAuthModule } from 'angular-oauth2-oidc';

import { AppComponent } from './app.component';
import { UserModule } from './user/user.module';
import { ProductModule } from './product/product.module';
import { ErrorComponent } from './shared/error/error.component';
import { AppInitializer } from './app.initializer';
import { ApiInterceptor } from './interceptors/api.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { NavbarComponent } from './navbar/navbar.component';
import { ContactComponent } from './contact/contact.component';
import { ShellComponent } from './shell/shell.component';

@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent,
    NavbarComponent,
    ContactComponent,
    ShellComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    UserModule,
    ProductModule,
    OAuthModule.forRoot()
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' },
  // { provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  {
    provide: APP_INITIALIZER,
    useFactory: InitializationServiceFactory,
    deps: [
      AppInitializer
    ],
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }


export function InitializationServiceFactory(initializationService: AppInitializer) {
  return () => initializationService.load();
}

