import { SkillCategory } from 'src/app/modules/users-table/models/skillCategory';

export interface Skill {
  skillId: number;
  description: string;
  categoryId: number;
  skillCategory: SkillCategory;
}
