import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Survey } from './models/survey.model';
import { Question } from './models/question.model';
import { Option } from './models/option.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:5197/api'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  getSurveys(): Observable<Survey[]> {
    return this.http.get<Survey[]>(`${this.baseUrl}/Survey`); // Note the uppercase "S" in "Survey"
  }
}
