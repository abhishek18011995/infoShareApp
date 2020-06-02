import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // console.log(route);
    // console.log(state);
    console.log('authentication : ' + this.authService.isAuthenticated());
    if (!this.authService.isAuthenticated()) {
      this.authService.setRedirectUrl(route.routeConfig.path);
      this.router.navigate(['login']);
    }
    return this.authService.isAuthenticated();
  }
}
