import { Component, OnInit, Input } from '@angular/core';
import { Skill } from 'src/app/shared/shared-models/skill';

@Component({
  selector: 'app-skill-card',
  templateUrl: './skill-card.component.html',
  styleUrls: ['./skill-card.component.css']
})
export class SkillCardComponent implements OnInit {
  val1: number;
  @Input() skill: Skill = {} as Skill;

  constructor() { }

  ngOnInit() {
  }
  
}
