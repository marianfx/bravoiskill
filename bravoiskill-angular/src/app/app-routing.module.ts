import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './modules/login/components/login.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './modules/home/components/home.component';
import { AuthGuard } from './auth/auth-guards/auth.guard';
import { UsersTableComponent } from './modules/users-table/components/users-table.component';
import { AuthAdmin } from './auth/auth-guards/auth.admin';
import { ProfileComponent } from './modules/profile/components/profile.component';
import { ColleaguesComponent } from './modules/colleagues/colleagues-component/colleagues.component';


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'tables', component: UsersTableComponent, canActivate: [AuthAdmin && AuthGuard]},
  { path: 'profile/:id', component: ProfileComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent},
  { path: 'colleagues', component: ColleaguesComponent, canActivate: [AuthGuard]},
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

