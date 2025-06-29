import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Feedback {
  id?: string;
  recipient: string;
  whatWentWell: string;
  whatCouldImprove: string;
  rating: number;
  submittedAt?: Date;
}

export interface AnalyticsData {
  totalFeedback: number;
  averageRating: number;
}

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private feedbackApiUrl = environment.apiUrl + '/api/feedback';

  constructor(private http: HttpClient) { }

  getFeedbacks(): Observable<Feedback[]> {
    return this.http.get<Feedback[]>(this.feedbackApiUrl);
  }

  getFeedback(id: string): Observable<Feedback> {
    return this.http.get<Feedback>(`${this.feedbackApiUrl}/${id}`);
  }

  createFeedback(feedback: Feedback): Observable<Feedback> {
    return this.http.post<Feedback>(this.feedbackApiUrl, feedback);
  }

  updateFeedback(id: string, feedback: Feedback): Observable<any> {
    return this.http.put(`${this.feedbackApiUrl}/${id}`, feedback);
  }

  deleteFeedback(id: string): Observable<any> {
    return this.http.delete(`${this.feedbackApiUrl}/${id}`);
  }

  getAnalytics(): Observable<AnalyticsData> {
    return this.http.get<AnalyticsData>(`${this.feedbackApiUrl}/analytics`);
  }
}
