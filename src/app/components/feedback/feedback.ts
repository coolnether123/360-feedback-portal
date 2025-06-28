import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Feedback, FeedbackService } from '../../services/feedback';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.html',
  styleUrls: ['./feedback.scss'],
  imports: [FormsModule]
})
export class FeedbackComponent {
  feedback: Feedback = {
    recipient: '',
    feedbackText: '',
    feedbackType: 'kudos'
  };

  constructor(private feedbackService: FeedbackService) { }

  onSubmit() {
    this.feedbackService.createFeedback(this.feedback).subscribe(() => {
      // Optionally, you can reset the form or show a success message
      this.feedback = {
        recipient: '',
        feedbackText: '',
        feedbackType: 'kudos'
      };
    });
  }
}
