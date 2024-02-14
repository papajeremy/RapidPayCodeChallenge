using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidPayApi.Authentication;

namespace RapidPayApi.Data
{
    public class IdentityContext : IdentityDbContext<RapidPayUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) 
            : base(options)
        {            
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );
        }
    }
}
