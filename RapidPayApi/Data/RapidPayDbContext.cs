using Microsoft.EntityFrameworkCore;
using RapidPayApi.Models;

namespace RapidPayApi.Data
{
    public class RapidPayDbContext : DbContext
    {
        public RapidPayDbContext( DbContextOptions<RapidPayDbContext> options )
            : base( options )
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardTransaction> CardTransactions { get; set; }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.Entity<Card>().HasData(
                new Card
                {
                    Id = 1,
                    Balance = 4500,
                    CardHolderFirstName = "Steve",
                    CardHolderLastName = "Rogers",
                    CardLimit = 35000,
                    CardNumber = "123456789098765",
                    CompanyName = "The Avengers Group",
                    ExpirationDate = new DateTime( 2025, 11, 30, 23, 59, 59 ),
                    CreatedDate = new DateTime( 2012, 05, 04, 13, 13, 13 ),
                    ModifiedDate = new DateTime( 2023, 10, 15, 10, 11, 12 )
                },
                new Card 
                { 
                    Id = 2, 
                    Balance = 8000, 
                    CardHolderFirstName = "Han", 
                    CardHolderLastName = "Solo", 
                    CardLimit = 17000, 
                    CardNumber = "135792648013579", 
                    CompanyName = "Millennium", 
                    ExpirationDate = new DateTime( 2026, 03, 31, 23, 59, 59 ),
                    CreatedDate = new DateTime( 2002, 08, 11, 19, 18, 17 ),
                    ModifiedDate = new DateTime( 2018, 12, 24, 11, 48, 23 )
                },
                new Card 
                { 
                    Id = 3, 
                    Balance = 175639, 
                    CardHolderFirstName = "Bruce", 
                    CardHolderLastName = "Wayne", 
                    CardLimit = 200000, 
                    CardNumber = "183729406560492", 
                    CompanyName = "Wayne Enterprises", 
                    ExpirationDate = new DateTime( 2025, 12, 31, 23, 59, 59 ),
                    CreatedDate = new DateTime( 2009, 10, 16, 11, 22, 32 ),
                    ModifiedDate = new DateTime( 2024, 01, 01, 00, 11, 56 )
                }
            );

            builder.Entity<CardTransaction>().HasData(
                new CardTransaction
                {
                    CardTransactionId = 1,
                    CardId = 1,
                    TransactionAmount = 2000,
                    TransactionFee = 16.25,
                    TransactionDate = new DateTime( 2023, 08, 02, 13, 23, 34 )
                },
                new CardTransaction
                {
                    CardTransactionId = 2,
                    CardId = 1,
                    TransactionAmount = 2500,
                    TransactionFee = 10.56,
                    TransactionDate = new DateTime( 2023, 12, 18, 16, 02, 52 )
                },
                new CardTransaction
                {
                    CardTransactionId = 3,
                    CardId = 2,
                    TransactionAmount = 1500,
                    TransactionFee = 14.26,
                    TransactionDate = new DateTime( 2022, 04, 16, 10, 40, 41 )
                },
                new CardTransaction
                {
                    CardTransactionId = 4,
                    CardId = 3,
                    TransactionAmount = 3500,
                    TransactionFee = 3.36,
                    TransactionDate = new DateTime( 2022, 09, 13, 09, 06, 08 )
                },
                new CardTransaction
                {
                    CardTransactionId = 5,
                    CardId = 3,
                    TransactionAmount = 3000,
                    TransactionFee = 6.69,
                    TransactionDate = new DateTime( 2023, 01, 23, 12, 17, 23 )
                }
            );
        }
    }
}
