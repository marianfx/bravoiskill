import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

// @NgModule({
//   imports: [
//     CommonModule,
//     RouterModule.forRoot(routes, {
//       useHash: true
//     })
//   ],
//   exports: [
//     RouterModule
//   ]
// })
export const AppRoutingModule = RouterModule.forRoot(routes);
