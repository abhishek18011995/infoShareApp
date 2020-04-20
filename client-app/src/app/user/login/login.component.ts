import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userName: string;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(loginForm: NgForm) {
    // console.log(loginForm);
    if (loginForm.valid) {
      const userName = loginForm.value.userName;
      this.authService.login(userName).subscribe(resp => {
        console.log(resp);
      });
    }
  }

  getProduct() {
    this.authService.testLogin().subscribe(resp => {
      console.log('resp');
    });
  }

}
