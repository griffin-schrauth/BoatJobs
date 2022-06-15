using Microsoft.EntityFrameworkCore;
using Boats.API.Models;

namespace Boats.API.Data
{
    public class BoatsDbContext: DbContext
    {
        public BoatsDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Boat> Boats { get; set; }
    }
}
