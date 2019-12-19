import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SkillCategory } from 'src/app/modules/users-table/models/skillCategory';
import { Skill } from 'src/app/shared/shared-models/skill';

@Component({
  selector: 'app-skill-category',
  templateUrl: './skill-category.component.html',
  styleUrls: ['./skill-category.component.css']
})
export class SkillCategoryComponent implements OnInit {

  @Input() skillSubCategory: SkillCategory = {} as SkillCategory;
  @Input() skillPoints: {skill: Skill, points: number}[] = [];
  @Input() open;
  expanded: boolean = false;

  constructor() { }

  ngOnInit() {
  }
}
