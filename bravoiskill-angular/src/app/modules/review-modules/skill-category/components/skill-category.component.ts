import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SkillCategory } from 'src/app/modules/users-table/models/skillCategory';
import { Skill } from 'src/app/shared/shared-models/skill';

@Component({
  selector: 'app-skill-category',
  templateUrl: './skill-category.component.html',
  styleUrls: ['./skill-category.component.css']
})
export class SkillCategoryComponent implements OnInit {

  @Input() skillSubCategory: SkillCategory;
  @Input() skills: Skill[];
  @Output() allSkillPoints = new EventEmitter<{skill: Skill;points: number}[]>();
  skillsPoints: {skill: Skill;points: number}[] = [];

  expanded: boolean = false;
  getSkillPoints(skillPoints){
   let index = this.skillsPoints.findIndex(x => x.skill.skillId == skillPoints.skill.skillId);
    if(index != -1)
      this.skillsPoints.splice(index,1,skillPoints);
    else
    this.skillsPoints.push(skillPoints);
    // console.log(this.skillsPoints);
  }
  onSkillCategory(){
    this.allSkillPoints.emit(this.skillsPoints);
  }
  constructor() { }

  ngOnInit() {
  }
}
