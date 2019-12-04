import { Component, OnInit } from '@angular/core';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/shared-models/user';
import { Review } from 'src/app/shared/shared-models/review';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-reviews-comments',
  templateUrl: './reviews-comments.component.html',
  styleUrls: ['./reviews-comments.component.css']
})
export class ReviewsCommentsComponent implements OnInit {
  public cUser: User = {} as User;
  private routeSub: Subscription;
  reviews: Review[] = [];
  expanded = [];

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute) { }

  ngOnInit() {
    this.getUserMet();
  }
  
  getSkillPercenter(points: number){
    let response = (points * 10) + '%';
    return response;
  }

  getImageUrl(id: number){
    return "url('" + `${environment.AppRoot}/users/${id}/photo` + "')";
  }

  getUserMet() {
    this.routeSub = this.route.params.subscribe(params => {
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.getReviews();
        });
      }
    });
  }

  getReviews(){
    this.reviewService.getAllReviewsFor(this.cUser.userId).subscribe( x => {
      this.reviews = x;
      this.expanded = [];
      for(var i = 0; i < this.reviews.length; i++)
        this.expanded.push(false);
      console.log(this.reviews);
    })
  }

}
