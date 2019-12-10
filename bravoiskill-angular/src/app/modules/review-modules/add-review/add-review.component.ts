import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SkillCategory } from '../../users-table/models/skillCategory';
import { User } from 'src/app/shared/shared-models/user';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Skill } from 'src/app/shared/shared-models/skill';
import { SkillService } from 'src/app/shared/shared-services/skill.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  public cUser: User = {} as User;
  private routeSub: Subscription;
  skills: Skill[] = [];
  expandedC: boolean[] = [];
  categories: any = []
  subCategories: any;

  @Input() displayDialogAddRev: boolean;
  @Output() displayDialogAddRevChange = new EventEmitter();

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute, public skillService: SkillService) { }

  ngOnInit() {
    this.getSkills();
    this.getCategories();
    this.getSubCategories();
  }

  getSubCategories() {
    this.skillService.getCategories().subscribe(r => {
      r.forEach(x => this.categories.push(x.description));
      this.categories.forEach(x => this.expandedC.push(false));
    });
  }

  getCategories() {
    this.skillService.getSubCategories().subscribe(r => this.subCategories = r);
  }

  getSkillsForSubCategory(categoryId: number) {
    return this.skills.filter(s => s.categoryId == categoryId);
  }

  getSubCategoryForCategory(categoryId: number) {
    return this.subCategories.filter(c => c.parentId == categoryId);
  }

  getSkills() {
    this.skillService.getAllSkills().subscribe(x => {
      this.skills = x;
      console.log("This are the skills !");
      console.log(this.skills);
    });
  }

  closeModal() {
    this.displayDialogAddRevChange.emit(false);
  }

  // getUserMet() {
  //   this.routeSub = this.route.params.subscribe(params => {
  //     if (params && params["id"]) {
  //       this.userService.getUserById(+params["id"]).subscribe(user => {
  //         this.cUser = user;
  //         this.getCategories();
  //       });
  //     }
  //   });
  // }

  // getCategories(){
  //   this.reviewService.getAllReviewsFor(this.cUser.userId).subscribe( x => {
  //     this.skillCategories = x;
  //     this.expanded = [];
  //     for(var i = 0; i < this.reviews.length; i++)
  //       this.expanded.push(false);
  //     console.log(this.reviews);
  //   })
  // }

}
