import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reviews-comments',
  templateUrl: './reviews-comments.component.html',
  styleUrls: ['./reviews-comments.component.css']
})
export class ReviewsCommentsComponent implements OnInit {
  public show: boolean = false;
  public buttonName: any = 'See more';

  constructor() { }

  ngOnInit() {
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
