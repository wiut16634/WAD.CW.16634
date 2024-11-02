export interface Question {
    QuestionId: number;
    QuestionText: string;
    QuestionDescription: string;
    SurveyId: number; // Foreign key
    questionType: string; // e.g., 'multiple-choice', 'text'
}