import { Injectable, OnInit } from "@angular/core";
import { Skill } from "src/app/shared/shared-models/skill";
import { SkillService } from "src/app/shared/shared-services/skill.service";
import { SkillCategory } from '../users-table/models/skillCategory';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/shared/shared-models/user';
import { Subscription } from 'rxjs';
import { Review } from 'src/app/shared/shared-models/review';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { ActivatedRoute } from '@angular/router';

@Injectable()
export class SkillPoints implements OnInit {
  private allSkillPoints: { skill: Skill; points: number }[] = [];
  private categories: SkillCategory[] = [];
  private cUser: User = {} as User;
  private routeSub: Subscription;
  private reviews: Review[] = [];
  constructor(private skillService: SkillService, private http: HttpClient, private reviewService: ReviewService, private userService: UserService, private route: ActivatedRoute) {
    this.skillService.getAllSkills().subscribe(sl => {
      sl.forEach(s =>
        this.allSkillPoints.push({ skill: s, points: 0 } as {
          skill: Skill;
          points: number;
        })
      );
    });
  }

  ngOnInit() {
this.getUserMet();
  }

  getAllSkillPoints(){
    return this.allSkillPoints;
  }

  getAllSkillPointsCategories(){
    return this.allSkillPoints.filter( x => x.skill.categoryId);
  }

  getAllSkillSubCategories() {

    this.skillService.getSubCategories().subscribe(x => x.forEach(y => this.categories.push(y)));
    return this.categories;
  }

  getSubSkillPointsForCategoryId(categoryId: number) {
    return this.allSkillPoints.filter(s => s.skill.categoryId == categoryId);
  }

  getSkillPointsForSkillId(skillId: number) {
    return this.allSkillPoints.filter(s => s.skill.skillId == skillId);
  }

  updateSkill(skill: Skill, value: number){

    let index = this.allSkillPoints.findIndex(s => skill.skillId == s.skill.skillId);
    if(index != -1)
      this.allSkillPoints.splice(index,1,{skill: skill, points: value} as {skill: Skill, points: number});
    else
      this.allSkillPoints.push({skill: skill, points: value} as {skill: Skill, points: number});

    console.log(this.allSkillPoints);
  }

  addReviewToServer(review: any){
    return this.http.post(`${environment.AppRoot}/reviews/add`, review);
  }
  private updateReviews() {
    this.reviewService.getAllReviewsFor(this.cUser.userId).subscribe(x => {
      this.reviews = x;
    })
  }
  getReviews(){
    return this.reviews;
  }
  getUserMet() {
    this.routeSub = this.route.params.subscribe(params => {
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.updateReviews();
        });
      }
    });
  }



}
