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
            new TransactionDto { 
                TransactionId = 1, 
                TransactionAmount = 2000,
                TransactionFee = 16.25,
                TransactionDate = new DateTime( 2023, 08, 02, 13, 23, 34 ) 
            },
            new TransactionDto { 
                TransactionId = 2, 
                TransactionAmount = 2500,
                TransactionFee = 10.56,
                TransactionDate = new DateTime( 2023, 12, 18, 16, 02, 52 ) 
            },
            new TransactionDto { 
                TransactionId = 1, 
                TransactionAmount = 1500,
                TransactionFee = 14.26,
                TransactionDate = new DateTime( 2022, 04, 16, 10, 40, 41 ) 
            },
            new TransactionDto { 
                TransactionId = 2, 
                TransactionAmount = 3500,
                TransactionFee = 3.36,
                TransactionDate = new DateTime( 2022, 09, 13, 09, 06, 08 ) 
            },
            new TransactionDto { 
                TransactionId = 3, 
                TransactionAmount = 3000,
                TransactionFee = 6.69,
                TransactionDate = new DateTime( 2023, 01, 23, 12, 17, 23 ) 
            },
        };
    }
}
