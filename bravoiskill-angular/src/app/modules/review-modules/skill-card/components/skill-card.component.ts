import { Component, OnInit, Input, ViewEncapsulation, Output, EventEmitter } from '@angular/core';
import { Skill } from 'src/app/shared/shared-models/skill';


@Component({
  selector: 'app-skill-card',
  templateUrl: './skill-card.component.html',
  styleUrls: ['./skill-card.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SkillCardComponent implements OnInit {
   val1: number;
  @Input() skill: Skill = {} as Skill;
  @Output() skillPoints = new EventEmitter<{skill:Skill; points:number}>();
  constructor() { }

  ngOnInit() {
  }

  onSkillCard(val1: any){
    let emitData: any = {skill: this.skill, points: val1};
    this.skillPoints.emit(emitData);
  }

  getClass() {
    if(this.val1 >= 0 && this.val1<=3)
      return 'red';
    else if(this.val1 > 3 && this.val1<=6)
      return 'yellow';
    else if(this.val1 > 6 && this.val1<=8)
      return 'green';
    else return 'blue';
  }
}
