// Import HttpClientModule
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { SurveyListComponent } from './survey-list/survey-list.component'; // Update this import as necessary
import { ApiService } from './api.service'; // Update this import as necessary
import { QuestionListComponent } from './question-list/question-list.component';
import {QuestionFormComponent} from './question-form/question-form.component'
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    SurveyListComponent,
    QuestionListComponent,
    QuestionFormComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule, 
    RouterModule.forRoot([]),
    FormsModule // Make sure FormsModule is included here
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule {}


