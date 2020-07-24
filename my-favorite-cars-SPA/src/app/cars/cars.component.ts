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
  xi: any;
  x2: any;

  test: {
    id: 1;
    name: 'Lamborghini Huracan';
    url: 'https://cdn.carbuzz.com/gallery-images/2020-lamborghini-huracan-evo-front-angle-view-carbuzz-529237-1600.jpg';
    motor: 'V10';
  };

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCars();
    //this.postCar();
    //this.deleteCar(1023);
  }

  postCar() {
    interface CarsInter {
      id: number;
      name: string;
    }
    this.http
      .post<CarsInter>('http://localhost:5000/api/cars/', {
        name: 'Lamborghini Huracan Spyder',
        brand: 'Lamborghini',
        model: '2020',
        url:
          'https://cdn.carbuzz.com/gallery-images/2020-lamborghini-huracan-evo-spyder-carbuzz-551818.jpg',
        motor: 'V10',
      })
      .subscribe(
        (response) => {
          this.xi = response.id;
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getCars() {
    this.http.get('http://localhost:5000/api/cars/').subscribe(
      (response) => {
        this.cars = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  deleteCar(id) {
    this.http.delete<any>('http://localhost:5000/api/cars/' + id).subscribe(
      (res) => {
        this.x2 = res.id;
      },
      (error) => {
        console.log(error);
      }
    );

    window.location.reload();
  }
}
