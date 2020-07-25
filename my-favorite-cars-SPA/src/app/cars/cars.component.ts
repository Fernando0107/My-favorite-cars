import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css'],
})
export class CarsComponent implements OnInit {
  // Variables
  cars: any;
  alm: any;
  car_id: any;
  cars_url = 'http://localhost:5000/api/cars/';
  showModal: boolean;
  registerForm: FormGroup;
  submitted = false;
  carName: string = '';
  carBrand: string = '';
  carUrl: string = '';
  carMotor: string = '';
  carModel: string = '';

  // Constructor
  constructor(private http: HttpClient, private formBuilder: FormBuilder) {}

  show() {
    this.showModal = true; // Show-Hide Model Check
  }

  hide() {
    this.showModal = false;
  }

  // On init
  ngOnInit(): void {
    this.getCars();

    this.registerForm = this.formBuilder.group({
      car: [''],
      brand: [''],
      model: [''],
      url: [''],
      motor: [''],
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  // Methods
  postCar(
    car: string,
    _brand: string,
    _model: string,
    _url: string,
    _motor: string
  ) {
    interface CarsInter {
      id: number;
      name: string;
    }

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
          this.car_id = response.id;
          console.log(this.car_id);
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
  testx(
    _car: string,
    _brand: string,
    _model: string,
    _url: string,
    _motor: string
  ) {
    console.log('HELLO');
    console.log(_car);
    console.log(_brand);
    console.log(_model);
    console.log(_url);
    console.log(_motor);

    this.submitted = true;

    if (this.submitted) {
      this.showModal = false;
    }
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
    this.submitted = true;

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

    if (this.submitted) {
      this.showModal = false;
    }
  }
}
