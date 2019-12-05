import { Component, OnInit, Input } from '@angular/core';
import { Review } from 'src/app/shared/shared-models/review';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  @Input() review: Review;
  @Input() expanded: boolean[];

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
