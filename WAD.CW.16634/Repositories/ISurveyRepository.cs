using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    public interface ISurveyRepository
    {
        //16634 Set a contract to the real Repository (must be implemented)
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int id);
        Task CreateSurveyAsync(Survey survey);
        Task UpdateSurveyAsync(Survey survey);
        Task DeleteSurveyAsync(int id);
        bool SurveyExists(int id);
    }
}
