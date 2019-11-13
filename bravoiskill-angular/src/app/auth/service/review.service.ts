import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ReviewService {
  constructor(private http: HttpClient) {}

  getAllReviews() {
    return this.http
      .get<Review[]>(`${environment.AppRoot}/reviews`);
  }
  deleteReview(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.AppRoot}/reviews/${id}`);
  }
  getReviewById(id: number){
    return this.http.get<Review>(`${environment.AppRoot}/reviews/${id}`);
  }

  createReview(review: Review){
    return this.http.post(`${environment.AppRoot}/reviews`,review);
  }

  editReview(id: number, review: Review): Observable<void>{
    return this.http.put<void>(`${environment.AppRoot}/reviews/${id}`,review);
  }

}
