import { Routes } from '@angular/router';
import { loginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

export const routes: Routes = [
    {
        path: '' , redirectTo:'login', pathMatch:'full'
    },
    {
        path:'login',
        component:loginComponent
    },
    {
        path: 'dashboard',
        component:DashboardComponent
    }
];
