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
    }
}
