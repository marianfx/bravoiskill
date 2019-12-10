import { Component, OnInit, Input } from '@angular/core';
import { SkillCategory } from 'src/app/modules/users-table/models/skillCategory';

@Component({
  selector: 'app-skill-category',
  templateUrl: './skill-category.component.html',
  styleUrls: ['./skill-category.component.css']
})
export class SkillCategoryComponent implements OnInit {

  @Input() skillCategory: SkillCategory;
  @Input() expandedC: boolean;

  constructor() { }

  ngOnInit() {
  }
}
