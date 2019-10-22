import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { UsersTableComponent } from './users-table/users-table.component';
import { AuthAdmin } from './auth/auth.admin';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'tables', component: UsersTableComponent, canActivate: [AuthAdmin]},
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, {
      useHash: true
    })
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

