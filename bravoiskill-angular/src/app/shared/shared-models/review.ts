import { SkillReview } from 'src/app/modules/profile-reviews/models/skillReview';
import { User } from './user';

export interface Review {
  reviewId: number;
  reviewDate: Date;
  comment: string;
  reviewedUserId: number;
  reviewerUserId: number;
  reviewSkills: SkillReview[];
  user: User;
}
