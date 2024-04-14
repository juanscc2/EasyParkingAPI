import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface User {
  id: number;
  name: string;
  email: string;
  username:string;
  idRole:number
  // Agrega aquí los demás campos que necesites
}

@Component({
  selector: 'app-prueba-get',
  template: `
    <h1>Lista de usuarios</h1>
    <ul *ngIf="users && users.length > 0">
      <li *ngFor="let user of users">
        {{ user.name }} ({{ user.email }})
      </li>
    </ul>
    <p *ngIf="!users || users.length === 0">No hay usuarios disponibles.</p>
  `,
})
export class PruebaGetComponent implements OnInit {
  users: User[] | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any>('https://localhost:7222/api/User/GetUsers')
      .subscribe(
        (data) => {
          this.users = data as User[];
        },
        (error) => {
          console.error(error);
          this.users = [];
        }
      );
  }
}