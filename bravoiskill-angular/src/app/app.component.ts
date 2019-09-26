import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { AuthenticationService } from './auth/service/authentication.service';
import { User } from './auth/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BravoiSkill';
  values: any;
  currentUser: User;

  constructor(){}



}
