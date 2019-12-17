import { Component, OnInit, Input } from '@angular/core';
import { Review } from 'src/app/shared/shared-models/review';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css']
})
export class CardComponent implements OnInit {

  @Input() review: Review;
  expanded: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  getImageUrl(id: number){
    return "url('" + `${environment.AppRoot}/users/${id}/photo` + "')";
  }

  getSkillPercenter(points: number){
    let response = (points * 10) + '%';
    return response;
  }

}