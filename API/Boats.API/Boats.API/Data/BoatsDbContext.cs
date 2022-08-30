using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Boats.API.Configurations.Entities;

namespace Boats.API.Data
{
    public class BoatsDbContext: IdentityDbContext<ApiUser>
    {
        public BoatsDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Boat> Boats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}
