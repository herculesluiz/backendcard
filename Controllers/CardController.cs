using BackEndCard.Models;
using BackEndCard.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BackEndCard.Controllers
{
    

    [ApiController]
    [Route("card")]
    
    public class CardController : ControllerBase
    {
               
        [HttpGet("{email}")]
        public IActionResult Read(string email, [FromServices]ICardRepository repository) 
        {
            
            var cards = repository.Read(email);
            if (cards.Count!=0)
                return Ok(cards);
            return NotFound();

        }
        [HttpPost]
        public IActionResult Create([FromBody]Card model, [FromServices]ICardRepository repository)
        {
                        
            if(!ModelState.IsValid)
                return BadRequest();
            
            if(model.Email==null || model.Email=="")
                return BadRequest();
            
            var cards = repository.Create(model);
            return Ok(cards);

        }
    }
}
