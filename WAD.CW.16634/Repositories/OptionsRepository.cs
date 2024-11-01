using WAD.CW._16634.Data;
using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    public class OptionsRepository: IOptionsRepository
    {
        private readonly ApplicationDbContext _context;

        public OptionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Option> GetOptionsByQuestionId(int questionId)
        {
            return _context.Options.Where(o => o.QuestionId == questionId).ToList();
        }

        public void Add(Option option)
        {
            _context.Options.Add(option);
            _context.SaveChanges();
        }

        public void Update(Option option)
        {
            _context.Options.Update(option);
            _context.SaveChanges();
        }

        public void Delete(int optionId)
        {
            var option = GetById(optionId);
            if (option != null)
            {
                _context.Options.Remove(option);
                _context.SaveChanges();
            }
        }

        public Option GetById(int optionId)
        {
            return _context.Options.Find(optionId);
        }
    }
}
