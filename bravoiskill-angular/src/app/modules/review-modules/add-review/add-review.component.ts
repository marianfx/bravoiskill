import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SkillCategory } from '../../users-table/models/skillCategory';
import { User } from 'src/app/shared/shared-models/user';
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

  @Input() cUser: User = {} as User;
  skills: Skill[] = [];
  subCategories: SkillCategory[] = [];

  @Input() displayDialogAddRev: boolean;
  @Output() displayDialogAddRevChange = new EventEmitter();

  constructor(public reviewService: ReviewService, public userService: UserService, public route: ActivatedRoute, public skillService: SkillService) { }

  ngOnInit() {
    this.getSkills();
    this.getSubCategories();
  }

  getSubCategories() {
    this.skillService.getSubCategories().subscribe(r => {
      r.forEach(x => this.subCategories.push(x));
    });
  }

  getSkillsForSubCategory(categoryId: number) {
    return this.skills.filter(s => s.categoryId == categoryId);
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
}
