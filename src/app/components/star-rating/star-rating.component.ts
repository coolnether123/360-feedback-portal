import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-star-rating',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.scss']
})
export class StarRatingComponent {
  @Input() rating: number = 0;
  @Output() ratingChange = new EventEmitter<number>();

  stars: number[] = [1, 2, 3, 4, 5];

  setRating(value: number) {
    this.rating = value;
    this.ratingChange.emit(this.rating);
  }

  getStarIcon(star: number): string {
    return star <= this.rating ? 'assets/star_filled.png' : 'assets/star_unfilled.png';
  }
}
