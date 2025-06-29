import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Feedback as FeedbackInterface, DataService } from '../../services/data.service';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { StarRatingComponent } from '../star-rating/star-rating.component'; // Import StarRatingComponent

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.html',
  styleUrls: ['./feedback.scss'],
  standalone: true,
  imports: [
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    StarRatingComponent // Add StarRatingComponent
  ]
})
export class FeedbackComponent {
  feedback: FeedbackInterface = {
    recipient: '',
    whatWentWell: '',
    whatCouldImprove: '',
    rating: 0
  };

  constructor(private dataService: DataService) { }

  onSubmit() {
    this.dataService.createFeedback(this.feedback).subscribe(() => {
      // Optionally, you can reset the form or show a success message
      this.feedback = <FeedbackInterface>{
        recipient: '',
        whatWentWell: '',
    whatCouldImprove: '',
    rating: 0
      };
    });
  }
}
