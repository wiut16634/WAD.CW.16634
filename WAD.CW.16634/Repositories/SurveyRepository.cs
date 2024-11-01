using Microsoft.EntityFrameworkCore;
using WAD.CW._16634.Data;
using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    //16334
    public class SurveyRepository: ISurveyRepository //implementing Interface
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task CreateSurveyAsync(Survey survey)
        {
            survey.CreatedAt = DateTime.Now;
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSurveyAsync(Survey survey)
        {
            _context.Entry(survey).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.SurveyId == id);
        }
    }
}
