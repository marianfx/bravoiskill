import { Component, OnInit } from '@angular/core';
import { User } from '../../../shared/shared-models/user';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../../../shared/shared-services/user.service';
import { ReviewService } from '../services/review.service';
import { SkillService } from 'src/app/shared/shared-services/skill.service';
import { UserSkill } from '../models/userSkill';




@Component({
  selector: 'app-profile-reviews-table',
  templateUrl: './profile-reviews-table.component.html',
  styleUrls: ['./profile-reviews-table.component.css']
})

export class ProfileReviewsTableComponent implements OnInit {

  public skills: UserSkill[];
  public cUser: User = {} as User;
  public canMessage: boolean = false;
  private routeSub: Subscription;
  user: User = {} as User;
  colsSkills = [
    { field: 'skill', header: 'Skill' },
    { field: 'points', header: 'Points' },
  ];
  public paginator: boolean = false;


  constructor(public http: HttpClient,
     public route: ActivatedRoute, public userService: UserService, public reviewService: ReviewService, public skillService: SkillService) {}

  ngOnInit() {
    this.getUserMet();

  }

  getSkillsPoints(){
    this.skillService.getUserSkillByUserId(this.cUser.userId).subscribe( x =>
      { this.skills = x;
        if(this.skills.length>10)
          this.paginator = true;});
  }



  getUserMet() {
    // // this.route
    // get route parameter
    // check id not null
    // get user by id using user service
    // populate curentUser with resulted user
    this.routeSub = this.route.params.subscribe(params => {
      // console.log(params) //log the entire params object
      if(params && params['id']) {
        this.userService.getUserById(+(params['id'])).subscribe(user => {
        this.cUser = user;
        this.getSkillsPoints();
        });
      }
    });
  }

}

