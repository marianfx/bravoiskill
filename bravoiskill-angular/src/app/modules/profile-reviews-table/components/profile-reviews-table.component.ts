import { Component, OnInit } from '@angular/core';
import { User } from '../../../shared/shared-models/user';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../../../shared/shared-services/user.service';
import { ReviewService } from '../services/review.service';
import { Review } from '../models/review';


@Component({
  selector: 'app-profile-reviews-table',
  templateUrl: './profile-reviews-table.component.html',
  styleUrls: ['./profile-reviews-table.component.css']
})

export class ProfileReviewsTableComponent implements OnInit {

  public reviews: Review[];
  public cUser: User = {} as User;
  public canMessage: boolean = false;
  private routeSub: Subscription;
  user: User = {} as User;
  colsReview = [
    { field: 'reviewerUserId', header: 'Reviewer' },
    { field: 'skill', header: 'Skill' },
    { field: 'points', header: 'Points' },
    { field: 'comment', header: 'Comment' },
    { field: 'reviewDate', header: 'Review Date' }
  ];


  constructor(public http: HttpClient,
     public route: ActivatedRoute, public userService: UserService, public reviewService: ReviewService) {}

  ngOnInit() {
    this.getUserMet();
  }

  getReviewsFor(id: number){
    this.reviewService.getAllReviewsFor(id).subscribe(x => {this.reviews = x;console.log(x);});
  }


  getUserMet() {
    // // this.route
    // get route parameter
    // check id not null
    // get user by id using user service
    // populate curentUser with resulted user
    this.routeSub = this.route.params.subscribe(params => {
      // console.log(params) //log the entire params object
      console.log(params['id']) //log the value of id
      if(params && params['id']) {
        this.userService.getUserById(+(params['id'])).subscribe(user => {
          this.cUser = user;
          this.getReviewsFor(this.cUser.userId);
          console.log(user);
        });
        console.log(this.cUser.userId);
      }
    });
  }

}

