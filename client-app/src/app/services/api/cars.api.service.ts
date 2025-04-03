import { Injectable } from '@angular/core';
import { ApiService } from './api.service'; 
import { Observable } from 'rxjs';
import { Car } from '../../models/car';

@Injectable({
  providedIn: 'root'
})
export class CarApiService {
  
  constructor(private apiService: ApiService) {}

  getAll(yearFilter?: number): Observable<Car[]> {
    let url = "cars"
    console.log(yearFilter)
    if (yearFilter) {
      url += `?year=${yearFilter}`
    }
    return this.apiService.sendApiRequest(url, 'GET');
  }

  add(car: Car): Observable<Car> {
    return this.apiService.sendApiRequest('cars', 'POST', car);
  }

  delete(carId: string): Observable<Car> {
    return this.apiService.sendApiRequest(`cars/${carId}`, 'DELETE');
  }
}
