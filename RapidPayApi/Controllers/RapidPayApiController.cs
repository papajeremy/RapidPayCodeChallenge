using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPayApi.Data;
using RapidPayApi.Models;
using RapidPayApi.Models.Dto;
using RapidPayApi.Services;

namespace RapidPayApi.Controllers
{
    [Authorize]
    [Route( "api/RapidPayApi" )]
    [ApiController]
    public class RapidPayApiController : ControllerBase
    {
        private readonly PaymentFeeService _paymentFeeService;
        private readonly RapidPayDbContext _dbContext;

        public RapidPayApiController( PaymentFeeService paymentFeeService, RapidPayDbContext dbContext )
        {
            _paymentFeeService = paymentFeeService;
            _dbContext = dbContext;
        }

        [HttpGet( Name = "GetCardBalance" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status401Unauthorized )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetCardBalance( string cardNumber )
        {
            if ( cardNumber == null ) return BadRequest();
            var card = await _dbContext.Cards.FirstOrDefaultAsync( c=>c.CardNumber == cardNumber );
            if ( card == null ) return NotFound();
            var cardBalance = card.Balance;
            return Ok( $"Card Balance: {card.Balance}" );  
        }

        [HttpPost]
        [ProducesResponseType( StatusCodes.Status201Created )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status401Unauthorized )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> CreateCardAsync( [FromBody] CardDto dto )
        {
            if ( dto == null ) return BadRequest( dto );
            if ( await _dbContext.Cards.FirstOrDefaultAsync( c => c.CardNumber == dto.CardNumber ) != null )
            {
                ModelState.AddModelError( "Duplicate Entry", "Card number already exists" );
            }
            if ( await _dbContext.Cards
                .FirstOrDefaultAsync( c => c.CardHolderFirstName.ToLower() == dto.CardHolderFirstName.ToLower() ) != null
                && await _dbContext.Cards
                .FirstOrDefaultAsync( c => c.CardHolderLastName.ToLower() == dto.CardHolderLastName.ToLower() ) != null )
            {
                ModelState.AddModelError( "Duplicate Entry", "User account already exists" );
            }
            Card card = new()
            {
                CardNumber = dto.CardNumber,
                ExpirationDate = dto.ExpirationDate,
                CardLimit = dto.CardLimit,
                CardHolderFirstName = dto.CardHolderFirstName,
                CardHolderLastName = dto.CardHolderLastName,
                CompanyName = dto.CompanyName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
            };
            _dbContext.Cards.Add( card );
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute( "GetCardBalance", new { cardNumber = dto.CardNumber }, dto );
        }

        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status204NoContent )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        [ProducesResponseType( StatusCodes.Status401Unauthorized )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> PayTransaction( [FromBody] CardTransactionDto transactionDto )
        {
            if ( transactionDto == null
                || String.IsNullOrEmpty( transactionDto.CardNumber )
                || transactionDto.TransactionAmount == 0 ) return BadRequest();
            var card = await _dbContext.Cards.FirstOrDefaultAsync( c=>c.CardNumber == transactionDto.CardNumber );
            if ( card == null ) return NotFound();
            CardTransaction newTransactionEntry = await CreateTransactionEntry(transactionDto);
            if(card.Balance + newTransactionEntry.TransactionTotal > card.CardLimit ) return BadRequest( error: "Transaction is over the limit. Transaction aborted." );
            _dbContext.CardTransactions.Add( newTransactionEntry );
            card.Balance = card.Balance + newTransactionEntry.TransactionTotal;
            card.ModifiedDate = DateTime.UtcNow;
            _dbContext.Cards.Add( card );
            await _dbContext.SaveChangesAsync();
            return Ok( newTransactionEntry );
        }

        private async Task<CardTransaction> CreateTransactionEntry( CardTransactionDto transactionDto )
        {
            var lastTransaction = await _dbContext.CardTransactions
                .OrderByDescending(t=>t.TransactionDate).FirstOrDefaultAsync();
            var randomTransactionFee = _paymentFeeService.RandomFee( lastTransaction.TransactionFee,
                lastTransaction.TransactionDate );
            var card = await _dbContext.Cards.FirstOrDefaultAsync( c => c.CardNumber == transactionDto.CardNumber );
            if ( card == null ) throw new KeyNotFoundException();
            CardTransaction cardtransactionEntry = new ()
            {
                CardId = card.Id,
                TransactionAmount = transactionDto.TransactionAmount,
                TransactionFee = randomTransactionFee,
                TransactionTotal = transactionDto.TransactionAmount + randomTransactionFee,
                TransactionDate = DateTime.UtcNow
            };
            return cardtransactionEntry;
        }
    }
}
