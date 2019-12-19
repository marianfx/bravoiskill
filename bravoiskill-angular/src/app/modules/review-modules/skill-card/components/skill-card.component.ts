import { Component, OnInit, Input, ViewEncapsulation} from '@angular/core';
import { Skill } from 'src/app/shared/shared-models/skill';
import { SkillPoints } from '../../skill-points.service';


@Component({
  selector: 'app-skill-card',
  templateUrl: './skill-card.component.html',
  styleUrls: ['./skill-card.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SkillCardComponent implements OnInit {
   val1: number;
  @Input() skillPoint: {skill: Skill, points: number} = {} as {skill: Skill, points: number};

  constructor(private skillPoints: SkillPoints) { }

  ngOnInit() {
    this.val1 = this.skillPoint.points;
  }

  getClass() {
    if(this.val1 >= 0 && this.val1 <= 3)
      return 'red';
    else if(this.val1 > 3 && this.val1 <= 6)
      return 'yellow';
    else if(this.val1 > 6 && this.val1 <= 8)
      return 'green';
    else return 'blue';
  }

  onChangeValue(){
    this.skillPoints.updateSkill(this.skillPoint.skill, this.val1);
  }
}
