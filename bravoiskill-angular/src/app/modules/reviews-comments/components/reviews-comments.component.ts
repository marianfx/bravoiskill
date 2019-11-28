import { Component, OnInit } from '@angular/core';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/shared-models/user';
import { Review } from 'src/app/shared/shared-models/review';

@Component({
  selector: 'app-reviews-comments',
  templateUrl: './reviews-comments.component.html',
  styleUrls: ['./reviews-comments.component.css']
})
export class ReviewsCommentsComponent implements OnInit {
  public show: boolean = false;
  public buttonName: any = 'See more';

  public cUser: User = {} as User;
  private routeSub: Subscription;
  reviews: Review[] = [];
  reviewers: any;

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute) { }

  ngOnInit() {
    this.getUserMet();
  }

  getUserMet() {
    this.routeSub = this.route.params.subscribe(params => {
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.getReviews();
          this.getReviewersFor(this.cUser.userId);
        });
      }
    });
  }
  getReviews(){
    this.reviewService.getAllReviewsFor(this.cUser.userId).subscribe( x => {
      this.reviews = x;
      console.log(this.reviews);
    })
  }
  getReviewersFor(id: number){
    this.userService.getUsersReviewersByReviewedUserId(id).subscribe(x =>{
      this.reviewers = x.reduce((m, o) => {
        m[o.userId] = o;
        return m;
    }, {});
    })
  }

  toggle() {
    this.show = !this.show;
    // CHANGE THE NAME OF THE BUTTON.
    if(this.show)
      this.buttonName = "See less";
    else
      this.buttonName = "See more";
  }
}


