import { Component, OnInit, Input } from '@angular/core';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/shared-models/user';
import { SkillPoints } from '../../skill-points.service';

@Component({
  selector: 'app-reviews-comments',
  templateUrl: './reviews-comments.component.html',
  styleUrls: ['./reviews-comments.component.css']
})
export class ReviewsCommentsComponent implements OnInit {
  public cUser: User = {} as User;
  private routeSub: Subscription;

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute, public skillPointsService: SkillPoints) {}

  ngOnInit() {
    this.getUserMet();
  }

  getUserMet() {
    this.routeSub = this.route.params.subscribe(params => {
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.skillPointsService.updateReviews(this.cUser.userId);
        });
      }
    });
  }
}
