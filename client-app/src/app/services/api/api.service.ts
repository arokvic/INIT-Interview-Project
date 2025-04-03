import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  sendApiRequest(
    url: string,
    method: string,
    body: any = null,
    headers: HttpHeaders = new HttpHeaders()
  ): Observable<any> {
    const requestUrl = `${this.baseUrl}/${url}`;
    let options = { headers };

    let request: Observable<any>;

    switch (method.toUpperCase()) {
      case 'GET':
        request = this.http.get(requestUrl, options); 
        break;
      case 'POST':
        request = this.http.post(requestUrl, body, options); 
        break;
      case 'PUT':
        request = this.http.put(requestUrl, body, options); 
        break;
      case 'DELETE':
        request = this.http.delete(requestUrl, options);
        break;
      default:
        return throwError('Unsupported HTTP method');
    }

    return request.pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Client-side error: ${error.error.message}`;
    } else {
      errorMessage = `Server-side error: ${error.status} - ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
