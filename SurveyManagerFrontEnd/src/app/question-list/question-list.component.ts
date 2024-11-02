// src/app/components/survey-details/survey-details.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Survey } from '../models/survey.model'
import {Question} from '../models/question.model'
import {Option} from '../models/option.model'

@Component({
  selector: 'app-question-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {
  surveyId!: number;
  survey!: Survey; // Holds the survey details
  questions: Question[] = []; // Holds the questions related to the survey
  options: { [questionId: number]: Option[] } = {}; // Holds options keyed by questionId

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.surveyId = +params['id']; // Get survey ID from route
      this.fetchSurveyDetails();
    });
  }

  private fetchSurveyDetails(): void {
    this.apiService.getSurveyById(this.surveyId).subscribe({
      next: (survey: Survey) => {
        this.survey = survey; // Set survey details
        this.fetchQuestions(); // Fetch associated questions
      },
      error: (err: any) => {
        console.error('Error fetching survey', err);
      }
    });
  }

  private fetchQuestions(): void {
    this.apiService.getAllQuestions().subscribe({
      next: (questions: Question[]) => {
        this.questions = questions.filter(q => q.surveyId === this.surveyId); // Filter questions by survey ID
        this.fetchOptions(); // Fetch options after getting questions
      },
      error: (err: any) => {
        console.error('Error fetching questions', err);
      }
    });
  }

  private fetchOptions(): void {
    this.apiService.getAllOptions().subscribe({
      next: (options: Option[]) => {
        // Group options by questionId
        options.forEach(option => {
          if (!this.options[option.questionId]) {
            this.options[option.questionId] = [];
          }
          this.options[option.questionId].push(option);
        });

        // No need to reassign here; just ensure options are keyed correctly
      },
      error: (err: any) => {
        console.error('Error fetching options', err);
      }
    });
  }
}