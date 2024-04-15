import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Route } from '@angular/router';

export class Login {
  Username: string;
  Password: string;
  constructor() {
    this.Username = '';
    this.Password = '';
  }
}

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginObj: Login = new Login();
  constructor(private http: HttpClient) {}
  onLogin() {
    this.http.post('http://localhost:7222/api/AuthenticationUser/Authentication', this.loginObj).subscribe((res: any) => {
      if (res.true) {
        alert("Login success");
      } else {
        alert(res.message);
      }
    });
  }
}