import { Injectable, OnInit } from "@angular/core";
import { Skill } from "src/app/shared/shared-models/skill";
import { SkillService } from "src/app/shared/shared-services/skill.service";
import { SkillCategory } from '../users-table/models/skillCategory';

@Injectable()
export class SkillPoints implements OnInit {
  private allSkillPoints: { skill: Skill; points: number }[] = [];
  private categories: SkillCategory[] = [];
  constructor(private skillService: SkillService) {
    this.skillService.getAllSkills().subscribe(sl => {
      sl.forEach(s =>
        this.allSkillPoints.push({ skill: s, points: 0 } as {
          skill: Skill;
          points: number;
        })
      );
      console.log("Astea sunt datele din serviciu: ");
      console.log(this.allSkillPoints);
    });
  }

  ngOnInit() {

  }

  getAllSkillPointsCategories(){
    return this.allSkillPoints.filter( x => x.skill.categoryId);
  }

  getAllSkillSubCategories() {

    this.skillService.getSubCategories().subscribe(x => x.forEach(y => this.categories.push(y)));
    console.log(this.categories);
    return this.categories;
  }

  getSubSkillPointsForCategoryId(categoryId: number) {
    return this.allSkillPoints.filter(s => s.skill.categoryId == categoryId);
  }

  getSkillPointsForSkillId(skillId: number) {
    return this.allSkillPoints.filter(s => s.skill.skillId == skillId);
  }

  updateSkill(skill: Skill, value: number){

    let index = this.allSkillPoints.findIndex(s => skill.skillId == s.skill.skillId);
    if(index != -1)
      this.allSkillPoints.splice(index,1,{skill: skill, points: value} as {skill: Skill, points: number});
    else
      this.allSkillPoints.push({skill: skill, points: value} as {skill: Skill, points: number});

    console.log(this.allSkillPoints);
  }
}
