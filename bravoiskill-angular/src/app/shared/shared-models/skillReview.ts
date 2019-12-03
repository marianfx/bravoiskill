import { Skill } from 'src/app/shared/shared-models/skill';

export interface SkillReview {
  reviewPoints: number;
  skillId: number;
  reviewId: number;
  skill: Skill;
}
