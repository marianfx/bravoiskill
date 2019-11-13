export interface Review {
  reviewId: number;
  reviewDate: Date;
  comment: string;
  reviewedUserId: number;
  reviewerUserId: number;
}
