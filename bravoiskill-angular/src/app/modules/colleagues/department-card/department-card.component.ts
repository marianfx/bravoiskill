import { Component, OnInit, Input } from '@angular/core';
import { Department } from 'src/app/shared/shared-models/department';
import { User } from 'src/app/shared/shared-models/user';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { Route } from '@angular/compiler/src/core';
import { RouteConfigLoadEnd, Router } from '@angular/router';

@Component({
  selector: 'app-department-card',
  templateUrl: './department-card.component.html',
  styleUrls: ['./department-card.component.css']
})
export class DepartmentCardComponent implements OnInit {
  colsUser: any[];
  displayDialogColeagues: boolean = false;
  users: User[] = [];
  @Input() department: Department;

  constructor(private uService: UserService) { }

  ngOnInit() {
    this.colsUser = [
      { field: 'userId', header: 'Id' },
      { field: 'firstName', header: 'First Name' },
      { field: 'lastName', header: 'Last Name' },
      { field: 'dateOfBirth', header: 'Date of birth' },
      { field: 'email', header: 'Email' },
      { field: 'skype', header: 'Skype' }];

    let unfilteredUsers:User[] = [];
    this.uService.getAllUsers().subscribe(users => {
      unfilteredUsers = users;
      this.users = unfilteredUsers.filter(uu => uu.departmentId === this.department.departmentId);
    });
  }

}
