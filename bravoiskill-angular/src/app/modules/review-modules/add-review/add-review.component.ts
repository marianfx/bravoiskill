import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SkillCategory } from '../../users-table/models/skillCategory';
import { User } from 'src/app/shared/shared-models/user';
import { ActivatedRoute } from '@angular/router';
import { ReviewService } from 'src/app/shared/shared-services/review.service';
import { Skill } from 'src/app/shared/shared-models/skill';
import { SkillPoints } from '../skill-points.service';
import { AuthenticationService } from 'src/app/auth/service/authentication.service';
import { Review } from 'src/app/shared/shared-models/review';
import { SkillReview } from 'src/app/shared/shared-models/skillReview';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-review',
  providers:[MessageService],
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  @Input() cUser: User = {} as User;
  @Input() displayDialogAddRev: boolean;
  @Output() displayDialogAddRevChange = new EventEmitter();
  reviewer: User = {} as User;
  comment: string = "";
  subCategories: SkillCategory[] = [];
  reviewSkillPoints: {skill: Skill; points: number}[] = [];
  userform: FormGroup;
  submitted: boolean = false;

  constructor(public reviewService: ReviewService, public route: ActivatedRoute, private skillPoints: SkillPoints, private authServ: AuthenticationService,
    private fb: FormBuilder, private messageService: MessageService) { }

  ngOnInit() {
    this.subCategories = this.skillPoints.getAllSkillSubCategories();
    this.authServ.currentUser.subscribe(x => this.reviewer = x);
    this.userform = this.fb.group(
      {'comment': new FormControl('', Validators.compose([Validators.required, Validators.maxLength(450)]))});}

  getAllSkillPointsForSubCategory(id:number){
    return this.skillPoints.getSubSkillPointsForCategoryId(id);
  }

  addReviewsToServer(){

    let reviewSkillPoints = this.skillPoints.getAllSkillPoints().filter( x => x.points != 0);
    let reviewSkillsToBeAdded: SkillReview[] = []
    reviewSkillPoints.forEach(r => {
      reviewSkillsToBeAdded.push({reviewPoints: r.points, skillId: r.skill.skillId} as SkillReview)
     // for skillReview reviewId: number;
    });
    let reviewToBeAdded = {reviewDate: new Date(), comment: this.comment, reviewedUserId: this.cUser.userId, reviewerUserId: this.reviewer.userId,
    reviewSkills: reviewSkillsToBeAdded} as Review;
    this.skillPoints.addReviewToServer(reviewToBeAdded).subscribe(response => {
      console.log(response); this.submitted = true;
      this.messageService.add({severity:'info', summary:'Success', detail:'Form Submitted'}),
      error => console.log(error);
      this.skillPoints.updateReviews(this.cUser.userId);
    });
  }

  closeModal(){
    this.displayDialogAddRevChange.emit(false);
    this.skillPoints.deleteSkillPointsData();
    this.comment = "";
  }
}
