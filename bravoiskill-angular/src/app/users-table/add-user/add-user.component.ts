import { Component, OnInit, Input } from '@angular/core';
import { NgModalsInterface } from 'ng-modals';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit, NgModalsInterface {
  toggleModal: any;

  data: any;

  constructor() { }

  ngOnInit() {
    console.log(this.data);
  }
}
