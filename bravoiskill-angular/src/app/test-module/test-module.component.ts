import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-module',
  templateUrl: './test-module.component.html',
  styleUrls: ['./test-module.component.css']
})
export class TestModuleComponent implements OnInit {

  cars: Car[] = [{vin: 1, year: 1996, brand:'Audi', color:'blue'} as Car,{vin: 2, year: 1997, brand:'BMW', color:'black'},
                 {vin: 1, year: 1996, brand:'Audi', color:'blue'} as Car,{vin: 2, year: 1997, brand:'BMW', color:'black'}];
  date = Date();
  constructor() { }

  ngOnInit() {
  }

}
export interface Car {
  vin;
  year;
  brand;
  color;
}
