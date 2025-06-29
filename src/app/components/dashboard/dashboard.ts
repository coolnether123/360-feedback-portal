import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { DataService, AnalyticsData } from '../../services/data.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MatCardModule, CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {
  analyticsData: AnalyticsData | null = null;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getAnalytics().subscribe(data => {
      this.analyticsData = data;
    });
  }
}
