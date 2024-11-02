import { Component } from '@angular/core';
import { Survey } from '../models/survey.model'; // Adjust the import path as necessary

@Component({
  selector: 'app-survey-creation',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css']
})
export class QuestionFormComponent {
  survey: Survey = { title: '', description: '', surveyId: 0, createdAt: new Date()}; // Initialize with your model structure

  onSubmit() {
    // Logic to save the survey (e.g., send to an API)
    console.log('Survey Created:', this.survey);
  }
}
