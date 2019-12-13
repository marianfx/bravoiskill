import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SkillCategory } from '../../users-table/models/skillCategory';
import { User } from 'src/app/shared/shared-models/user';
import { UserService } from 'src/app/shared/shared-services/user.service';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Skill } from 'src/app/shared/shared-models/skill';
import { SkillPoints } from '../skill-points.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  @Input() cUser: User = {} as User;
  @Input() displayDialogAddRev: boolean;
  @Output() displayDialogAddRevChange = new EventEmitter();

  subCategories: SkillCategory[] = [];


  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute, private skillPoints: SkillPoints) { }

  ngOnInit() {
    this.subCategories = this.skillPoints.getAllSkillSubCategories();
    console.log(this.subCategories);
  }

  getAllSkillPointsForSubCategory(id:number){
    return this.skillPoints.getSubSkillPointsForCategoryId(id);
  }

  closeModal() {
    this.displayDialogAddRevChange.emit(false);
  }
}
