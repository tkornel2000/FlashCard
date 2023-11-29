using FlashCardApp.Dtos;
using FlashCardApp.Models;
using FlashCardApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashCardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/<CardController>
        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetRandomListAsync()
        {
            return Ok(await _cardService.GetAllCardsRandomAsync());
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CardController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CardDto cardDto)
        {
            if (_cardService.CanIAdd(cardDto))
            {
                await _cardService.AddCardAsync(cardDto);
                return Ok();
            }
            else
            {
                return BadRequest("Már van ilyen magyar vagy német kifejezés hozzáadva");
            }
            
        }

        // PUT api/<CardController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> ModifyCardResultAsync(int id, [FromBody] bool isCorrect)
        {
            var result = await _cardService.ModifyCardResultAsync(id, isCorrect);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("No record with this id");
            }
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
