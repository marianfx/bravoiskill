import { Component, OnInit } from '@angular/core';
import { Department } from '../../../shared/shared-models/department';
import { DepartmentService } from 'src/app/shared/shared-services/department.service';

@Component({
  selector: 'app-colleagues',
  templateUrl: './colleagues.component.html',
  styleUrls: ['./colleagues.component.css']
})
export class ColleaguesComponent implements OnInit {

responsiveOptions;
departments: Department[] = [{departmentId: 1, description: "Loading..." } as Department];

  constructor(private depService: DepartmentService) {
    this.responsiveOptions = [
      {
          breakpoint: '1024px',
          numVisible: 3,
          numScroll: 3
      },
      {
          breakpoint: '768px',
          numVisible: 2,
          numScroll: 2
      },
      {
          breakpoint: '560px',
          numVisible: 1,
          numScroll: 1
      }
  ];
   }

  ngOnInit() {
    this.depService.getAllDepartments().subscribe(x => this.departments = x);
  }

}
