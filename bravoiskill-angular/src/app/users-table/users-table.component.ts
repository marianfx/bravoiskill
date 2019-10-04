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

  saveU1() {

    ///save user to back-end
    this.uService.createUser(this.user).subscribe(
      (response) => {console.log(response),this.uService.getAllUsers().subscribe(users => (this.users = users));},
      (error) => console.log(error));
    ///

    this.user = null;
    this.displayDialogU1 = false;

  }
  saveD1(){
    ///save user to back-end
    this.dService.createDepartment(this.department).subscribe(
      (response) => {console.log(response),this.dService.getAllDepartments().subscribe(departments => (this.departments = departments));},
      (error) => console.log(error));
    ///

    this.department = null;
    this.displayDialogD1 = false;
  }

  closeU1() {
    let index = this.users.indexOf(this.selectedUser);
    this.users = this.users.filter((val, i) => i != index);
    this.user = null;
    this.displayDialogU1 = false;
  }
  closeD1(){
    let index = this.departments.indexOf(this.selectedDepartment);
    this.departments = this.departments.filter((val, i) => i != index);
    this.department = null;
    this.displayDialogD1 = false;
  }

  deleteUser(id: number) {

    this.uService.deleteUser(id).subscribe(
      (response) => {console.log(response);this.uService.getAllUsers().subscribe(users => (this.users = users));},
      (error) => console.log(error));
  }

  saveUserEdit(id: number, user: User) {
///edit user in back-end
    this.uService.editUser(id, user).subscribe(
      (response) => {console.log(response);  this.uService.getAllUsers().subscribe(users => (this.users = users));},
      (error) => console.log(error),
     )
///
this.user = null;
this.displayDialogU2 = false;
  }
  saveDepartmentEdit(id: number, department: Department) {
    ///edit department in back-end
        this.dService.editDepartment(id, department).subscribe(
          (response) => {console.log(response);  this.dService.getAllDepartments().subscribe(departments => (this.departments = departments));},
          (error) => console.log(error),
         )
    ///
    this.department = null;
    this.displayDialogD2 = false;

      }

  onEditSelectUser(user: User) {
    this.newUser = false;
    this.user = this.cloneUser(user);
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
  cloneDepartment(c: Department): Department {
    let department = {} as Department;
    for (let prop in c) {
      department[prop] = c[prop];
    }
    console.log(department);
    console.log(c);
    return department;
  }


  // DEPARTMENT
  showDialogToAddDepartment() {
    this.newDepartment = true;
    this.department = {} as Department;
    this.displayDialogD1 = true;
  }
  deleteDepartment(departmentId: number){
    this.dService.deleteDepartment(departmentId).subscribe(
      (response) => {console.log(response);this.dService.getAllDepartments().subscribe(departments => (this.departments = departments));},
      (error) => console.log(error));
  }
  onEditSelectDepartment(department: Department){
    this.newDepartment = false;
    this.department = this.cloneDepartment(department);
    this.displayDialogD2 = true;
  }
}
