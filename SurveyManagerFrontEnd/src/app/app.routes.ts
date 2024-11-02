import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveyListComponent } from './survey-list/survey-list.component';
import { QuestionListComponent } from './question-list/question-list.component';

export const routes: Routes = [  // Add `export` keyword here
  { path: '', component: SurveyListComponent },
  { path: 'survey/:id/questions', component: QuestionListComponent },
];
