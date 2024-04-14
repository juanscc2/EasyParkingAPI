import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class loginComponent {
  loginObj: Login;
  constructor(private http: HttpClient, private router: Router) {
    this.loginObj = new Login();
  }

  onLogin() {
    console.log(this.loginObj);
    this.http
      .post(
        'http://localhost:5134/api/AuthenticationUser/Authentication',
        this.loginObj
      )
      .subscribe(
        () => {
          this.router.navigateByUrl('/dashboard');
        },
        (error) => {
          if(error.status==401){
            alert("Datos incorrectos")
          }
          
        }
      );
  }
}

export class Login {
  Username: string;
  Password: string;

  constructor() {
    this.Username = '';
    this.Password = '';
  }
}
