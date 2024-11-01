using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    public class OptionTextValidator: IOptionObserver
    {
        private readonly IOptionsRepository _optionRepository;

        public OptionTextValidator(IOptionsRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public void ValidateOption(Option option)
        {
            var existingOptions = _optionRepository.GetOptionsByQuestionId(option.QuestionId);

            if (existingOptions.Any(o => o.OptionText == option.OptionText && o.OptionId != option.OptionId))
            {
                throw new InvalidOperationException("Option title must be unique within the question.");
            }
        }
    }
}
