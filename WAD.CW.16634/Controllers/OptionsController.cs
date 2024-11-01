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

            option.Attach(_uniqueTitleValidator);

   
            option.Notify(); 
            _optionRepository.Add(option);

            return Ok($"Option '{option.OptionText}' created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOption(int id, [FromBody] Option updatedOption)
        {
            if (id != updatedOption.OptionId)
            {
                return BadRequest();
            }

            var existingOption = _optionRepository.GetById(id);
            if (existingOption == null)
            {
                return NotFound();
            }

        
            updatedOption.Attach(_uniqueTitleValidator);


            updatedOption.UpdateTitle(updatedOption.OptionText);
            _optionRepository.Update(updatedOption);

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
