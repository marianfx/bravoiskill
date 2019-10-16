import { Component, OnInit } from '@angular/core';
import { UserService } from '../auth/service/user.service';
import { MenuItem, SelectItem } from 'primeng/api';
import {AccordionModule} from 'primeng/accordion';
import { User } from '../auth/models/user';
import { Department } from '../auth/models/department';
import { DepartmentService } from '../auth/service/department.service';
import { Skill } from '../auth/models/skill';
import { SkillService } from '../auth/service/skill.service';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {

  items: MenuItem[];

  searchCategories: SelectItem[];
  searchCategoriesId: SelectItem[];

  displayDialogU1: boolean;
  displayDialogU2: boolean;
  user: User = {} as User;
  selectedUser: User;
  newUser: boolean;
  users: User[];
  colsUser: any[];
  alertDeleteSkill: boolean;
  alertDeleteUser: boolean;
  alertDeleteDepartment: boolean;

  displayDialogD1: boolean;
  displayDialogD2: boolean;
  department: Department = {} as Department;
  selectedDepartment: Department;
  newDepartment: boolean;
  departments: Department[];
  colsDepartment: any[];

  displayDialogS1: boolean;
  displayDialogS2: boolean;
  skill: Skill = {} as Skill;
  selectedSkill: Skill;
  newSkill: boolean;
  skills: Skill[];
  fullSkillsList: Skill[];
  colsSkill: any[];


  activeItem: MenuItem;

  constructor(private uService: UserService, private dService: DepartmentService, private sService: SkillService) { }

  ngOnInit() {
    this.uService.getAllUsers().subscribe(users => (this.users = users));
    this.dService.getAllDepartments().subscribe (departments => (this.departments = departments));
    this.sService.getAllSkills().subscribe(skills => (this.skills = skills));

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

    this.colsSkill = [
      { field: 'skillId', header: 'Id' },
      { field: 'description', header: 'Description' },
      { field: 'skillCategory', header: 'Category' }
    ];
    this.searchCategories = [
      { label: 'All Categories', value:  null },
      { label: 'Human Relations', value: "saa" },
      { label: 'Character', value: "Character" },
      { label: 'Web - Front-End', value: 'Web - Front-End' },
      { label: 'Desktop/Mobile', value: 'Desktop/Mobile' },
      { label: 'Databases', value: 'Databases' },
      { label: 'Q&A', value: 'Q&A' },
      { label: 'UI/UX', value: 'UI/UX' },
      { label: 'Business Analysis', value: 'Business Analysis' },
      { label: 'Sales', value: 'Sales' },
      { label: 'Management', value: 'Management' },
      { label: 'Digital', value: 'Digital' }
  ];
  this.searchCategoriesId = [
    { label: 'Human Relations', value: 3},
    { label: 'Character', value: 4},
    { label: 'Web - Front-End', value: 5},
    { label: 'Desktop/Mobile', value: 7},
    { label: 'Databases', value: 8},
    { label: 'Q&A', value: 9},
    { label: 'UI/UX', value: 10},
    { label: 'Business Analysis', value: 11},
    { label: 'Sales', value:12},
    { label: 'Management', value: 13},
    { label: 'Digital', value: 14}
];



  }

  // USER
  showDialogToAddUser() {
    this.newUser = true;
    this.user = {} as User;
    this.displayDialogU1 = true;
  }

  onDeleteUser(user: User) {
    this.user = this.cloneUser(user);
    this.alertDeleteUser = true;
  }

  closeAlertDeleteUser()
  {
    this.alertDeleteUser = false;
  }

  onDeleteDepartment(department: Department) {
    this.department = this.cloneDepartment(department);
    this.alertDeleteDepartment = true;
  }

  closeAlertDeleteDepartment()
  {
    this.alertDeleteDepartment = false;
  }
  onDeleteSkill(skill: Skill) {
    this.skill = this.cloneSkill(skill);
    this.alertDeleteSkill = true;
  }

  closeAlertDeleteSkill()
  {
    this.alertDeleteSkill = false;
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


  closeU1() {
    let index = this.users.indexOf(this.selectedUser);
    this.users = this.users.filter((val, i) => i != index);
    this.user = null;
    this.displayDialogU1 = false;
  }


  deleteUser(id: number) {
    this.uService.deleteUser(id).subscribe(
      (response) => {console.log(response);
                     this.uService.getAllUsers().subscribe(users => (this.users = users)); },
      (error) => console.log(error));
    this.alertDeleteUser = false;
  }

  saveUserEdit(id: number, user: User) {

// edit user in back-end
    this.uService.editUser(id, user).subscribe(
      (response) => {console.log(response);  this.uService.getAllUsers().subscribe(users => (this.users = users));},
      (error) => console.log(error),
     )
//
this.user = null;
this.displayDialogU2 = false;
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
    this.alertDeleteDepartment = false;
  }
  onEditSelectDepartment(department: Department){
    this.newDepartment = false;
    this.department = this.cloneDepartment(department);
    this.displayDialogD2 = true;
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
  cloneDepartment(c: Department): Department {
    let department = {} as Department;
    for (let prop in c) {
      department[prop] = c[prop];
    }
    console.log(department);
    console.log(c);
    return department;
  }
  closeD1(){
    let index = this.departments.indexOf(this.selectedDepartment);
    this.departments = this.departments.filter((val, i) => i != index);
    this.department = null;
    this.displayDialogD1 = false;
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

 //Skill
 showDialogToAddSkill() {
  this.newSkill = true;
  this.skill = {} as Skill;
  this.displayDialogS2 = false;
  this.displayDialogS1 = true;

}
deleteSkill(skillId: number){
  this.sService.deleteSkill(skillId).subscribe(
    (response) => {console.log(response);this.sService.getAllSkills().subscribe(skills => (this.skills = skills));},
    (error) => console.log(error));
    this.alertDeleteSkill = false;
}
onEditSelectSkill(skill: Skill){
  this.newSkill = false;
  this.skill = this.cloneSkill(skill);
  this.displayDialogS2 = true;
}
saveSkillEdit(id: number, skill: Skill) {
  ///edit department in back-end
      this.sService.editSkill(id, skill).subscribe(
        (response) => {console.log(response); this.sService.getAllSkills().subscribe(skills => (this.skills = skills));},
        (error) => console.log(error),
       )
  ///
  this.skill = null;
  this.displayDialogS2 = false;

}
cloneSkill(c: Skill): Skill {
  let skill = {} as Skill;
  for (let prop in c) {
    skill[prop] = c[prop];
  }
  console.log(skill);
  console.log(c);
  return skill;
}
closeS1(){
  let index = this.skills.indexOf(this.selectedSkill);
  this.skills = this.skills.filter((val, i) => i != index);
  this.skill = null;
  this.displayDialogS1 = false;
}
saveS1(){
  ///save user to back-end
  this.sService.createSkill(this.skill).subscribe(
    (response) => {console.log(response); this.sService.getAllSkills().subscribe(skills => (this.skills = skills));},
    (error) => console.log(error));
  ///

  this.skill = null;
  this.displayDialogS1 = false;
}
}
