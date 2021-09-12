import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class InsuranceDetailsService {
  constructor(private http: HttpClient) { }
  readonly baseURL = 'http://localhost:11671/';
  response: string = '';
  responseheaders: HttpHeaders = new HttpHeaders().append('responseType', 'json').append('Access-Control-Allow-Origin', 'http://localhost:4200')
    .append('Access-Control-Allow-Credentials', 'true');
  calculatePremium(age:any,rating:any,coverAmount:any) {
    return this.http.get<string>(this.baseURL+`${age}/${rating}/${coverAmount}`, {headers: this.responseheaders})
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );;
  }
  getOccupations() {
    return this.http.get(this.baseURL + 'api/Insurance/GetOccupations', { headers: this.responseheaders });
  }
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }

}