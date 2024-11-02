import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveyListComponent } from './survey-list/survey-list.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionFormComponent } from './question-form/question-form.component';

export const routes: Routes = [  // Add `export` keyword here
  { path: '', component: SurveyListComponent },
  { path: 'survey/:id/questions', component: QuestionListComponent },
  { path: 'survey/:id', component: QuestionListComponent },
  { path: 'create-survey', component: QuestionFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}