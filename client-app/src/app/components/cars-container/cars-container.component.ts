import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CarApiService } from '../../services/api/cars.api.service';
import { Car } from '../../models/car';

@Component({
  selector: 'app-cars-container',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './cars-container.component.html',
  styleUrl: './cars-container.component.css'
})
export class CarsContainerComponent implements OnInit {
  private carApiService = inject(CarApiService)
  private fb = inject(FormBuilder)

  cars: Car[] = []
  isLoading = false
  error: string | null = null
  showAddForm = false
  carForm: FormGroup
  maxYear: number = new Date().getFullYear()
  yearFilter: number | null = null

  constructor() {
    this.carForm = this.fb.group({
      model: ["", Validators.required],
      year: ["", [Validators.required, Validators.min(1900), Validators.max(this.maxYear)]],
      manufacturer: ["", Validators.required],
    })
  }

  ngOnInit(): void {
    this.loadCars()
  }

  loadCars(): void {
    this.isLoading = true
    this.error = null

    this.carApiService.getAll(this.yearFilter || undefined).subscribe({
      next: (data) => {
        this.cars = data
        this.isLoading = false
      },
      error: (err) => {
        this.error = "Failed to load cars: " + err
        this.isLoading = false
      },
    })
  }

  applyYearFilter(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.yearFilter = target.value ? Number.parseInt(target.value) : null;
    this.loadCars();
  }

  clearFilters(): void {
    this.yearFilter = null
    this.loadCars()
  }

  toggleAddForm(): void {
    this.showAddForm = !this.showAddForm
    if (this.showAddForm) {
      this.carForm.reset()
    }
  }

  get availableYears(): number[] {
    return Array.from(new Set(this.cars.map(car => car.year))).sort();
  }

  addCar(): void {
    if (this.carForm.invalid) {
      return;
    }
  
    const newCar: Omit<Car, "id"> = {
      model: this.carForm.value.model,
      year: Number.parseInt(this.carForm.value.year),
      manufacturer: this.carForm.value.manufacturer,
    };
  
    this.isLoading = true;
    this.carApiService.add(newCar as Car).subscribe({
      next: (car) => {
        // Refetch the cars list after adding the new car
        this.loadCars();
  
        // Optionally, you can also push the new car into the list immediately
        // this.cars.push(car);
  
        this.isLoading = false;
        this.showAddForm = false;
        this.carForm.reset();
      },
      error: (err) => {
        this.error = "Failed to add car: " + err;
        this.isLoading = false;
      },
    });
  }

  deleteCar(carId: string): void {
    if (confirm("Are you sure you want to delete this car?")) {
      this.isLoading = true
      this.carApiService.delete(carId).subscribe({
        next: () => {
          this.cars = this.cars.filter((car) => car.id !== carId)
          this.isLoading = false
        },
        error: (err) => {
          this.error = "Failed to delete car: " + err
          this.isLoading = false
        },
      })
    }
  }
}
