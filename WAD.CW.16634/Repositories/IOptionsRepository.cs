using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    public interface IOptionsRepository
    {
        Task<IEnumerable<Option>> GetAllOptionsAsync();
        IEnumerable<Option> GetOptionsByQuestionId(int questionId);
        void Add(Option option);
        void Update(Option option);
        void Delete(int optionId);
        Option GetById(int optionId);
    }
}
