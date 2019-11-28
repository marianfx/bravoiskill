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
  public show: boolean = false;
  public buttonName: any = 'See more';

  public cUser: User = {} as User;
  private routeSub: Subscription;
  reviews: Review[] = [];

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute) { }

  ngOnInit() {
    this.getUserMet();
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
      console.log(this.reviews);
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


