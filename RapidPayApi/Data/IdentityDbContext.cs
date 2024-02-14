using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidPayApi.Authentication;

namespace RapidPayApi.Data
{
    public class IdentityDbContext : IdentityDbContext<RapidPayUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
            : base(options)
        {            
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );
        }
    }
}
