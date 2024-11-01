using Microsoft.AspNetCore.Mvc;
using WAD.CW._16634.Models;
using WAD.CW._16634.Repositories;

namespace WAD.CW._16634.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepositroy _questionRepository;

        public QuestionController(IQuestionRepositroy questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuestion([FromBody] Question question)
        {
            await _questionRepository.CreateQuestionAsync(question);
            return Ok($"Question with ID {question.QuestionId} created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            await _questionRepository.UpdateQuestionAsync(question);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionRepository.DeleteQuestionAsync(id);
            return NoContent();
        }
    }
}
