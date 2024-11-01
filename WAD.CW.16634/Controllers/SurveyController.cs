using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.CW._16634.Data;
using WAD.CW._16634.Models;
using WAD.CW._16634.Repositories;

namespace WAD.CW._16634.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        //16634
        /// <summary>
        /// Just Initializing a Repository an calling a remote method.Makes the code clear
        /// </summary>
        private readonly ISurveyRepository _surveyRepository;

        public SurveyController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            var surveys = await _surveyRepository.GetAllSurveysAsync();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            var survey = await _surveyRepository.GetSurveyByIdAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateSurvey([FromBody] Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _surveyRepository.CreateSurveyAsync(survey);
            return Ok($"Survey named {survey.Title} is created!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, Survey survey)
        {
            if (id != survey.SurveyId)
            {
                return BadRequest();
            }

            if (!_surveyRepository.SurveyExists(id))
            {
                return NotFound();
            }

            await _surveyRepository.UpdateSurveyAsync(survey);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            if (!_surveyRepository.SurveyExists(id))
            {
                return NotFound();
            }

            await _surveyRepository.DeleteSurveyAsync(id);
            return NoContent();
        }
    }
}
