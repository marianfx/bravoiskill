import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { User } from './models/user.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BravoiSkill';
  values: any;
  users: User[];

  constructor(public uService: UserService) { }
  
  ngOnInit() {
    this.uService.getUser().subscribe((data) => {
      console.log(data);
      this.users = data;
    });
  }

}
