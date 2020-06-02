import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { ProductListComponent } from './product/product-list.component';
import { ErrorComponent } from './shared/error/error.component';
import { AuthGuardService } from './user/auth-guard.service';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { ContactComponent } from './contact/contact.component';
import { ShellComponent } from './shell/shell.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '', component: ShellComponent, children: [
      { path: 'home', component: ProductListComponent },
      { path: 'product/:id', component: ProductDetailsComponent, canActivate: [AuthGuardService] },
      { path: 'contact', component: ContactComponent, canActivate: [AuthGuardService] },
      { path: '', redirectTo: 'home', pathMatch: 'full' }
    ]
  },
  { path: 'error', component: ErrorComponent }
  // { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
