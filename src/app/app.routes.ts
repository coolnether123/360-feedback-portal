import { Routes } from '@angular/router';
import { Dashboard } from './components/dashboard/dashboard';
import { FeedbackComponent } from './components/feedback/feedback';
import { Admin } from './components/admin/admin';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'feedback', component: FeedbackComponent },
  { path: 'admin', component: Admin }
];