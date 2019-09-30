import { Component, OnInit } from '@angular/core';
import {TableModule} from 'primeng/table';
import { User } from '../auth/models/user';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../auth/service/user.service';


@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {
  users: User[];
  cols: any[];
  constructor(private uService: UserService) { }

  ngOnInit() {
      this.uService.getAllUsers().subscribe(users => this.users = users);
      this.cols = [
        { field: 'userId', header: 'Id' },
        { field: 'firstName', header: 'First Name' },
        { field: 'lastName', header: 'Last Name' },
        { field: 'dateOfBirth', header: 'Date of birth' },
        { field: 'email', header: 'Email' },
        { field: 'skype', header: 'Skype' }
    ];
  }
}




