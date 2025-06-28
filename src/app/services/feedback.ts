import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Feedback {
  id?: string;
  recipient: string;
  feedbackText: string;
  feedbackType: 'kudos' | 'constructive';
  submittedAt?: Date;
}

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  private apiUrl = '/api/feedback';

  constructor(private http: HttpClient) { }

  getFeedbacks(): Observable<Feedback[]> {
    return this.http.get<Feedback[]>(this.apiUrl);
  }

  getFeedback(id: string): Observable<Feedback> {
    return this.http.get<Feedback>(`${this.apiUrl}/${id}`);
  }

  createFeedback(feedback: Feedback): Observable<Feedback> {
    return this.http.post<Feedback>(this.apiUrl, feedback);
  }

  updateFeedback(id: string, feedback: Feedback): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, feedback);
  }

  deleteFeedback(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}