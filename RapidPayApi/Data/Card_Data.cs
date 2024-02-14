using RapidPayApi.Models.Dto;

namespace RapidPayApi.Data
{
    public class Card_Data
    {
        public static List<CardDto> cardList = new List<CardDto>
        {
            new CardDto { Id = 1, Active = true, Balance = 4500, CardHolderFirstName = "Steve", CardHolderLastName = "Rogers", CardLimit = 35000, CardNumber = "123456789098765", CompanyName = "The Avengers Group", ExpirationDate=new DateTime( 2025, 11, 30, 23, 59, 59 ) },
            new CardDto { Id = 2, Active = true, Balance = 8000, CardHolderFirstName = "Han", CardHolderLastName = "Solo", CardLimit = 17000, CardNumber = "135792648013579", CompanyName = "Millennium", ExpirationDate=new DateTime( 2026, 03, 31, 23, 59, 59 ) },
            new CardDto { Id = 3, Active = true, Balance = 0, CardHolderFirstName = "Bruce", CardHolderLastName = "Li", CardLimit = 22000, CardNumber = "183729406560492", CompanyName = "New Avengers", ExpirationDate=new DateTime( 2025, 12, 31, 23, 59, 59 ) }
        };

        public static List<TransactionDto> transactionList = new List<TransactionDto>
        {
            new TransactionDto { Id = 1, TransactionId = 1, Amount = 2000, TransactionDate = new DateTime( 2023, 08, 02, 13, 23, 34 ) },
            new TransactionDto { Id = 1, TransactionId = 2, Amount = 2500, TransactionDate = new DateTime( 2023, 12, 18, 16, 02, 52 ) },
            new TransactionDto { Id = 2, TransactionId = 1, Amount = 1500, TransactionDate = new DateTime( 2022, 04, 16, 10, 40, 41 ) },
            new TransactionDto { Id = 2, TransactionId = 2, Amount = 3500, TransactionDate = new DateTime( 2022, 09, 13, 09, 06, 08 ) },
            new TransactionDto { Id = 2, TransactionId = 3, Amount = 3000, TransactionDate = new DateTime( 2023, 01, 23, 12, 17, 23 ) },
        };
    }
}
