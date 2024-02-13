using Microsoft.AspNetCore.Mvc;
using RapidPayApi.Data;
using RapidPayApi.Models.Dto;

namespace RapidPayApi.Controllers
{
    [Route("api/RapidPayApi")]
    [ApiController]
    public class RapidPayApiController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCardAsync( [FromBody] CardDto dto )
        {
            if ( dto == null ) return BadRequest( dto );
            if ( Card_Data.cardList.FirstOrDefault(c=>c.Id == dto.Id) != null )
            {
                ModelState.AddModelError( "Duplicate Entry", "Card number already exists" );
            }
            if(Card_Data.cardList
                .FirstOrDefault(c=>c.CardHolderFirstName.ToLower() == dto.CardHolderFirstName.ToLower()) != null
                && Card_Data.cardList
                .FirstOrDefault(c=>c.CardHolderLastName.ToLower() == dto.CardHolderLastName.ToLower()) != null )
            {
                ModelState.AddModelError( "Duplicate Entry", "User account already exists" );
            }
            if ( dto.Id > 0 ) return StatusCode( StatusCodes.Status500InternalServerError );
            dto.Id = Card_Data.cardList.OrderByDescending( c => c.Id ).FirstOrDefault().Id + 1;
            Card_Data.cardList.Add( dto );
            return Ok( StatusCodes.Status201Created );
        }

        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetCardBalance(string cardNumber )
        {
            if ( cardNumber == null ) return BadRequest();
            var card = Card_Data.cardList.FirstOrDefault(c=>c.CardNumber == cardNumber );
            if ( card == null ) return NotFound();
            var cardBalance = card.Balance;
            return Ok( cardBalance );
        }


    }
}
