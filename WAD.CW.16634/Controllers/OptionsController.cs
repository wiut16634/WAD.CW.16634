using Microsoft.AspNetCore.Mvc;
using WAD.CW._16634.Models;
using WAD.CW._16634.Repositories;

namespace WAD.CW._16634.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsRepository _optionRepository;
        private readonly IOptionObserver _uniqueTitleValidator;

        public OptionsController(IOptionsRepository optionRepository)
        {
            _optionRepository = optionRepository;
            _uniqueTitleValidator = new OptionTextValidator(optionRepository); 
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
            var options = await _optionRepository.GetAllOptionsAsync();
            return Ok(options);
        }
        // 16634}
        [HttpGet("{id}")]
        public ActionResult<Option> GetOption(int id)
        {
            var option = _optionRepository.GetById(id);
            if (option == null)
            {
                return NotFound();
            }
            return option;
        }

   
        [HttpPost]
        public ActionResult CreateOption([FromBody] Option option)
        {

            try
            {
               
                option.Attach(_uniqueTitleValidator);
                option.Notify();

              
                _optionRepository.Add(option);

                return Ok($"Option '{option.OptionText}' created successfully.");
            }
            catch (InvalidOperationException ex)
            {
                
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOption(int id, [FromBody] Option updatedOption)
        {
            
            if (id != updatedOption.OptionId)
            {
                return BadRequest("Option ID mismatch.");
            }

            
            var existingOption = _optionRepository.GetById(id);
            if (existingOption == null)
            {
                return NotFound();
            }

            
            _uniqueTitleValidator.ValidateOption(updatedOption);

          
            existingOption.UpdateTitle(updatedOption.OptionText);

      
            _optionRepository.Update(existingOption);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteOption(int id)
        {
            var option = _optionRepository.GetById(id);
            if (option == null)
            {
                return NotFound();
            }

            _optionRepository.Delete(id);
            return NoContent();
        }
    }
}
