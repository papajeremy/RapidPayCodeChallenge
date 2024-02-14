using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RapidPayApi.Data;
using RapidPayApi.Models.Dto;
using RapidPayApi.Services;

namespace RapidPayApi.Controllers
{
    [Route("api/RapidPayApi")]
    [ApiController]
    public class RapidPayApiController : ControllerBase
    {
        private readonly PaymentFeeService _paymentFeeService;

        public RapidPayApiController(PaymentFeeService paymentFeeService)
        {
            _paymentFeeService = paymentFeeService;
        }
        [HttpGet(Name = "GetCardBalance")]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetCardBalance( string cardNumber )
        {
            if ( cardNumber == null ) return BadRequest();
            var card = Card_Data.cardList.FirstOrDefault(c=>c.CardNumber == cardNumber );
            if ( card == null ) return NotFound();
            var cardBalance = card.Balance;
            return Ok( $"CardBalance: {cardBalance}" );
        }

        [HttpPost]
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
            return CreatedAtRoute("GetCardBalance", new { cardNumber = dto.CardNumber }, dto );
        }        

        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status204NoContent )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PayTransaction( [FromBody] TransactionDto transactionDto )
        {
            if ( transactionDto == null 
                || String.IsNullOrEmpty(transactionDto.CardNumber) 
                || transactionDto.TransactionAmount == 0 ) return BadRequest();
            var card = Card_Data.cardList.FirstOrDefault( c=>c.CardNumber == transactionDto.CardNumber );
            if( card == null) return NotFound();
            TransactionDto newTransactionEntry = CreateTransactionEntry(transactionDto);
            card.Balance = card.Balance + newTransactionEntry.TransactionTotal;
            return Ok( newTransactionEntry );
        }

        private TransactionDto CreateTransactionEntry( TransactionDto transactionDto )
        {
            var lastTransaction = Card_Data.transactionList
                .OrderByDescending(t=>t.TransactionDate).FirstOrDefault();
            var randomTransactionFee = _paymentFeeService.RandomFee( lastTransaction.TransactionFee,
                lastTransaction.TransactionDate );
            TransactionDto transactionEntry = new ()
            {
                TransactionId = Card_Data.transactionList.Max( t=>t.TransactionId ) + 1,
                CardNumber = transactionDto.CardNumber,
                TransactionAmount = transactionDto.TransactionAmount,
                TransactionFee = randomTransactionFee,
                TransactionTotal = transactionDto.TransactionAmount + randomTransactionFee,
                TransactionDate = DateTime.UtcNow
            };
            return transactionEntry;
        }
    }
}
