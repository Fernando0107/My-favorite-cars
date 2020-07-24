import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css'],
})
export class CarsComponent implements OnInit {
  cars: any;
  today: number = Date.now();

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/api/cars/').subscribe(
      (response) => {
        this.cars = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
