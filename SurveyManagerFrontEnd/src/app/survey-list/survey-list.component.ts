import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Survey } from '../models/survey.model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.css']
})
export class SurveyListComponent implements OnInit {
  surveys: Survey[] = [];

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.apiService.getSurveys().subscribe({
      next: (data) => {
        this.surveys = data;
      },
      error: (err) => {
        console.error('Error fetching surveys', err);
      }
    });
  }

  // Method to navigate to the survey details page
  viewSurvey(surveyId: number): void {
    this.router.navigate(['/survey', surveyId]);
  }
}