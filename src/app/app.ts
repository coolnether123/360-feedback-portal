import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import { Dashboard } from './components/dashboard/dashboard';
import { Feedback } from './components/feedback/feedback';
import { Admin } from './components/admin/admin';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, Dashboard, FeedbackComponent, Admin],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
}
