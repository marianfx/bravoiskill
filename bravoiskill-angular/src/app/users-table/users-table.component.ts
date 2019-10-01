import { Component, OnInit } from '@angular/core';
import { User } from '../auth/models/user';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../auth/service/user.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {
  displayDialog: boolean;
  user: User = {} as User;
  selectedUser: User;
  newUser: boolean;
  users: User[];
  cols: any[];
  users1: User[];
  users2: User[];
  clonedUsers: { [s: string]: User; } = {};

  constructor(private uService: UserService, 
              private messageService: MessageService) { }

  ngOnInit() {
    this.uService.getAllUsers().subscribe(users => (this.users = users));
    this.uService.getAllUsers().subscribe(users => (this.users1 = users));
    this.uService.getAllUsers().subscribe(users => (this.users2 = users));
    
    this.cols = [
      { field: 'userId', header: 'Id' },
      { field: 'firstName', header: 'First Name' },
      { field: 'lastName', header: 'Last Name' },
      { field: 'dateOfBirth', header: 'Date of birth' },
      { field: 'email', header: 'Email' },
      { field: 'skype', header: 'Skype' }
    ];
  }

  showDialogToAdd() {
    this.newUser = true;
    this.user = {} as User;
    this.displayDialog = true;
  }

  save() {
    let users = [...this.users];
    if (this.newUser)
      users.push(this.user);
    else
      users[this.users.indexOf(this.selectedUser)] = this.user;

    this.users = users;
    this.user = null;
    this.displayDialog = false;
  }

  onRowEditInit(user: User) {
    this.clonedUsers[user.id] = { ...user };
  }

  onRowEditSave(user: User) {
    if (user.id > 0) {
      delete this.clonedUsers[user.id];
      this.messageService.add({ severity: 'success', summary: 'Success', detail: 'User is updated' });
    }
    else {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Year is required' });
    }
  }

  onRowEditCancel(user: User, index: number) {
    this.users2[index] = this.clonedUsers[user.id];
    delete this.clonedUsers[user.id];
  }
}
