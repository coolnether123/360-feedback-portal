import { Routes } from '@angular/router';
import { Dashboard } from './components/dashboard/dashboard';
import { FeedbackComponent } from './components/feedback/feedback';
import { Admin } from './components/admin/admin';
import { LoginComponent } from './auth/login/login.component'; // Import LoginComponent

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // Redirect to login
  { path: 'login', component: LoginComponent }, // Add login route
  { path: 'dashboard', component: Dashboard },
  { path: 'feedback', component: FeedbackComponent },
  { path: 'admin', component: Admin }
];