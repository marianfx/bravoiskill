import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { LoaderService } from '../shared-services/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {

  color: string = 'primary';
  mode: string = 'indeterminate';
  value: number = 50;
  isLoading: Subject<boolean> = this.loaderService.isLoading;


  constructor(private loaderService: LoaderService) { }

  ngOnInit() {
  }

}
