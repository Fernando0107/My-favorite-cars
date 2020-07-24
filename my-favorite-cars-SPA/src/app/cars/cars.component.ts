import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css'],
})
export class CarsComponent implements OnInit {
  // Variables
  cars: any;
  alm: any;
  cars_url = 'http://localhost:5000/api/cars/';

  // Constructor
  constructor(private http: HttpClient) {}

  // On init
  ngOnInit(): void {
    this.getCars();
  }

  // Methods
  postCar(
    car: string,
    _brand: string,
    _model: string,
    _url: string,
    _motor: string
  ) {
    this.http
      .post<CarsInter>(this.cars_url, {
        name: car,
        brand: _brand,
        model: _model,
        url: _url,
        motor: _motor,
      })
      .subscribe(
        (response) => {
          this.alm = response.id;
          console.log(this.alm);
        },
        (error) => {
          console.log(error);
        }
      );
    window.location.reload();
  }

  getCars() {
    this.http.get(this.cars_url).subscribe(
      (response) => {
        this.cars = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  deleteCar(id) {
    this.http.delete<any>(this.cars_url + id).subscribe(
      (res) => {
        this.alm = res.id;
      },
      (error) => {
        console.log(error);
      }
    );
    window.location.reload();
  }

  updateCar(
    id,
    car: string,
    _brand: string,
    _model: string,
    _url: string,
    _motor: string
  ) {
    this.http
      .put<any>(this.cars_url + id, {
        name: car,
        brand: _brand,
        model: _model,
        url: _url,
        motor: _motor,
      })
      .subscribe(
        (resp) => {
          this.alm = resp;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}

interface CarsInter {
  id: number;
  name: string;
}
