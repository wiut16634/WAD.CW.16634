using Microsoft.Extensions.Primitives;

namespace WAD.CW._16634.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionDescription { get; set; }
        public QuestionTypes QuestionType { get; set; }
    }
}
