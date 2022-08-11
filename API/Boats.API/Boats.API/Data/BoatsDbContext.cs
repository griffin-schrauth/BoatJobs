﻿using Microsoft.EntityFrameworkCore;
using Boats.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Boats.API.Data
{
    public class BoatsDbContext: IdentityDbContext<ApiUser>
    {
        public BoatsDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Boat> Boats { get; set; }
        
    }
}
