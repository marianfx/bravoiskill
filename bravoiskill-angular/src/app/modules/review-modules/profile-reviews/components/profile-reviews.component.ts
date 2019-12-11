import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { SkillService } from "src/app/shared/shared-services/skill.service";
import { UserSkill } from "../models/userSkill";
import { User } from 'src/app/shared/shared-models/user';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ReviewService } from 'src/app/shared/shared-services/review.service';

@Component({
  selector: "app-profile-reviews",
  templateUrl: "./profile-reviews.component.html",
  styleUrls: ["./profile-reviews.component.css"]
})
export class ProfileReviewsComponent implements OnInit {
  public skills: UserSkill[];
  public cUser: User = {} as User;
  public canMessage: boolean = false;
  private routeSub: Subscription;
  user: User = {} as User;
  colsSkills = [
    { field: "skill", header: "Skill" },
    { field: "points", header: "Points" }
  ];
  public paginator: boolean = false;
  public seeMore: boolean = false;
  barChartLabels = ["Loading..."];
  barChartType = "bar";
  barChartLegend = true;
  barChartData: any = [{ data: [0], label: "Loading..." }];
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true,
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
            stepValue: 50,
            steps: 10,
            min: 0
          }
        }
      ]
    }
  };
  public show: boolean = false;
  public buttonName: any = 'See more';

  constructor(
    public http: HttpClient,
    public route: ActivatedRoute,
    public userService: UserService,
    public reviewService: ReviewService,
    public skillService: SkillService
  ) { }

  ngOnInit() {
    this.getUserMet();
  }

  seeMoreActivate(element) {
    this.seeMore = !this.seeMore;
  }

  getChartButtonText() {
    return this.seeMore ? 'Back to charts' : 'See more';
  }

  getSkillsPoints() {
    this.skillService.getUserSkillByUserId(this.cUser.userId).subscribe(x => {
      this.skills = x;
      if (this.skills.length > 10) {
        this.paginator = true;
      }
      this.barChartData = [];
      let topSkills = [];
      this.skills.sort((n1, n2) => n2.points - n1.points);
      this.skills
        .slice(0, 5)
        .forEach(y =>
          this.barChartData.push({
            data: [y.points],
            label: y.skill.description
          })
        );
      this.barChartLabels = ["Skills"];
    });
  }

  getUserMet() {
    // // this.route
    // get route parameter
    // check id not null
    // get user by id using user service
    // populate curentUser with resulted user
    this.routeSub = this.route.params.subscribe(params => {
      // console.log(params) //log the entire params object
      if (params && params["id"]) {
        this.userService.getUserById(+params["id"]).subscribe(user => {
          this.cUser = user;
          this.getSkillsPoints();
        });
      }
    });
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
