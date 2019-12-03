import { Skill } from '../../../shared/shared-models/skill';

export interface UserSkill {
  points: number;
  userId: number;
  skillId: number;
  skill: Skill;
}
