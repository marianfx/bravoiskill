import { SkillReview } from '../../profile-reviews-table/models/skillReview';

export interface Review {
  reviewId: number;
  reviewDate: Date;
  comment: string;
  reviewedUserId: number;
  reviewerUserId: number;
  reviewSkills: SkillReview[];
}
