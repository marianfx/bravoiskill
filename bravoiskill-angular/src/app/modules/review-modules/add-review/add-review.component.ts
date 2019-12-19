import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SkillCategory } from '../../users-table/models/skillCategory';
import { User } from 'src/app/shared/shared-models/user';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Skill } from 'src/app/shared/shared-models/skill';
import { SkillPoints } from '../skill-points.service';
import { AuthenticationService } from 'src/app/auth/service/authentication.service';
import { Review } from 'src/app/shared/shared-models/review';
import { SkillReview } from 'src/app/shared/shared-models/skillReview';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  @Input() cUser: User = {} as User;
  @Input() displayDialogAddRev: boolean;
  @Output() displayDialogAddRevChange = new EventEmitter();
  reviewer: User = {} as User;
  comment: string = "";
  subCategories: SkillCategory[] = [];
  reviewSkillPoints: {skill: Skill; points: number}[] = [];

  constructor(public reviewService: ReviewService, public route: ActivatedRoute, private skillPoints: SkillPoints, private authServ: AuthenticationService) { }

  ngOnInit() {
    this.subCategories = this.skillPoints.getAllSkillSubCategories();
    this.authServ.currentUser.subscribe(x => this.reviewer = x);
  }

  getAllSkillPointsForSubCategory(id:number){
    return this.skillPoints.getSubSkillPointsForCategoryId(id);
  }

  addReviewsToServer(){
    let reviewSkillPoints = this.skillPoints.getAllSkillPoints().filter( x => x.points != 0);
    let reviewSkillsToBeAdded: SkillReview[] = []
    reviewSkillPoints.forEach(r => {
      reviewSkillsToBeAdded.push({reviewPoints: r.points, skillId: r.skill.skillId} as SkillReview)
     // for skillReview reviewId: number;
    });
    let reviewToBeAdded = {reviewDate: new Date(), comment: this.comment, reviewedUserId: this.cUser.userId, reviewerUserId: this.reviewer.userId,
    reviewSkills: reviewSkillsToBeAdded} as Review;
    this.skillPoints.addReviewToServer(reviewToBeAdded).subscribe(response => {
      console.log(response),
      error => console.log(error);
      this.skillPoints.updateReviews(this.cUser.userId);
    });
  }

  closeModal(){
    this.displayDialogAddRevChange.emit(false);
    this.skillPoints.deleteSkillPointsData();
    this.comment = "";
  }
}
