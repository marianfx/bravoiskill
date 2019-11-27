import { Skill } from '../../users-table/models/skill';

export interface UserSkill {
  points: number;
  userId: number;
  skillId: number;
  skill: Skill;
}
