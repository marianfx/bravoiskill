import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {
@Input() displayDialogAddRev: boolean;
  constructor() { }

  ngOnInit() {
  }

}
