import { SkillReview } from 'src/app/modules/profile-reviews/models/skillReview';

export interface Review {
  reviewId: number;
  reviewDate: Date;
  comment: string;
  reviewedUserId: number;
  reviewerUserId: number;
  reviewSkills: SkillReview[];
}