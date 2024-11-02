// Import HttpClientModule
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { SurveyListComponent } from './survey-list/survey-list.component'; // Update this import as necessary
import { ApiService } from './api.service'; // Update this import as necessary

@NgModule({
  declarations: [
    AppComponent,
    SurveyListComponent
    // Add other components here
  ],
  imports: [
    BrowserModule,
    HttpClientModule, // Add HttpClientModule here
    RouterModule.forRoot([]) // Update with your routes
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule {}

