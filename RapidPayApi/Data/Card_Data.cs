using RapidPayApi.Models.Dto;

namespace RapidPayApi.Data
{
    public class Card_Data
    {
        public static List<CardDto> cardList = new List<CardDto>
        {
            new CardDto { Id = 1, Active = true, Balance = 2500, CardHolderFirstName = "Steve", CardHolderLastName = "Rogers", CardLimit = 35000, CardNumber = "123456789098765", CompanyName = "The Avengers Group", ExpirationDate=new DateTime( 2025, 11, 30, 23, 59, 59 ) },
            new CardDto { Id = 2, Active = true, Balance = 15375, CardHolderFirstName = "Han", CardHolderLastName = "Solo", CardLimit = 17000, CardNumber = "135792648013579", CompanyName = "Millennium", ExpirationDate=new DateTime( 2026, 03, 31, 23, 59, 59 ) },
            new CardDto { Id = 3, Active = true, Balance = 0, CardHolderFirstName = "Bruce", CardHolderLastName = "Li", CardLimit = 22000, CardNumber = "183729406560492", CompanyName = "New Avengers", ExpirationDate=new DateTime( 2025, 12, 31, 23, 59, 59 ) }
        };
    }
}
