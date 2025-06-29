import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    // In a real application, you would make an HTTP POST request to your backend
    // For now, we'll simulate a successful login
    console.log(`Attempting to log in with email: ${email} and password: ${password}`);
    return of({ success: true, token: 'fake-jwt-token' });
  }
}
