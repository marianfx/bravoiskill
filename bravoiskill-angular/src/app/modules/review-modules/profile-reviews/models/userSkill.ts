import { Skill } from 'src/app/shared/shared-models/skill';

export interface UserSkill {
  points: number;
  userId: number;
  skillId: number;
  skill: Skill;
}
