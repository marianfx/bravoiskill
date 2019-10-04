import { Component, OnInit } from '@angular/core';
import { UserService } from '../auth/service/user.service';
import { MenuItem } from 'primeng/api';

import { User } from '../auth/models/user';
import { Department } from '../auth/models/department';
import { DepartmentService } from '../auth/service/department.service';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {
  items: MenuItem[];

  displayDialogU1: boolean;
  displayDialogU2: boolean;
  user: User = {} as User;
  selectedUser: User;
  newUser: boolean;
  users: User[];
  colsUser: any[];

  displayDialogD1: boolean;
  displayDialogD2: boolean;
  department: Department = {} as Department;
  selectedDepartment: Department;
  newDepartment: boolean;
  departments: Department[];
  colsDepartment: any[];

  activeItem: MenuItem;

  constructor(private uService: UserService, private dService: DepartmentService) { }

  ngOnInit() {
    this.uService.getAllUsers().subscribe(users => (this.users = users));
    this.dService.getAllDepartments().subscribe (departments => (this.departments = departments));

    this.items = [
      { label: 'Users', icon: 'fa fa-fw fa-user' },
      { label: 'Departments', icon: 'fa fa-fw fa-users' },
      { label: 'Skills', icon: 'fa fa-fw fa-cogs' }
    ];
    this.activeItem = this.items[0];

    this.colsUser = [
      { field: 'userId', header: 'Id' },
      { field: 'firstName', header: 'First Name' },
      { field: 'lastName', header: 'Last Name' },
      { field: 'dateOfBirth', header: 'Date of birth' },
      { field: 'email', header: 'Email' },
      { field: 'skype', header: 'Skype' }
    ];

    this.colsDepartment = [
      { field: 'departmentId', header: 'Id' },
      { field: 'description', header: 'Description' }
    ];
  }

  // USER
  showDialogToAddUser() {
    this.newUser = true;
    this.user = {} as User;
    this.displayDialogU1 = true;
  }

  showDialogToEditUser() {
    this.newUser = true;
    this.user = {} as User;
    this.displayDialogU2 = true;
  }

  save() {
    let users = [...this.users];
    if (this.newUser)
      {users.push(this.user);
      this.uService.getAllUsers().subscribe(users => (this.users = users));
    }
    else
      users[this.users.indexOf(this.selectedUser)] = this.user;
    this.users = users;

    ///save user to back-end
    this.uService.createUser(this.user).subscribe(
      (response) => console.log(response),
      (error) => console.log(error));
    ///

    this.user = null;
    this.displayDialogU1 = false;
    this.uService.getAllUsers().subscribe(users => (this.users = users));
  }

  close() {
    let index = this.users.indexOf(this.selectedUser);
    this.users = this.users.filter((val, i) => i != index);
    this.user = null;
    this.displayDialogU1 = false;
  }

  deleteU() {
    let index = this.users.indexOf(this.selectedUser);
    this.uService.deleteUser(index).subscribe(
      (response) => console.log(response),
      (error) => console.log(error));
  }

  saveEdit() {
///edit user in back-end
    this.uService.editUser(this.user.userId, this.user).subscribe(
      (response) => console.log(response),
      (error) => console.log(error));
///
    this.user = null;
    this.displayDialogU2 = false;
    this.uService.getAllUsers().subscribe(users => (this.users = users));

  }

  onEditSelect(event) {
    this.newUser = false;
    this.user = this.cloneUser(event.data);
    this.displayDialogU2 = true;
  }

  cloneUser(c: User): User {
    let user = {} as User;
    for (let prop in c) {
      user[prop] = c[prop];
    }
    console.log(user);
    console.log(c);
    return user;
  }


  // DEPARTMENT
  showDialogToAddDepartment() {

  }
}
