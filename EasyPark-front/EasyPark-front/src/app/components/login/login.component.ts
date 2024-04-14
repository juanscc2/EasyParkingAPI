import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { Route, Router } from "@angular/router";




@Component({
    selector: 'app-login',
    standalone: true,
    imports: [FormsModule, HttpClientModule],
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
  })
  export class loginComponent {

    loginObj: Login;
    constructor (private http: HttpClient, private router: Router) {
      this.loginObj = new Login();
    }

    onLogin() {
      this.http.post('http://localhost:5000/api/authenticationuser/authenticate', this.loginObj). subscribe((res:any)=> {
        if(res.result) {
          alert("login exitoso");
          this.router.navigateByUrl('/dashboard')
        } else {
          alert(res.message)
        }
      })
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