import { SkillCategory } from './skillCategory';

export interface Skill {
  skillId: number;
  description: string;
  categoryId: number;
  skillCategory: SkillCategory;
}
