using Boats.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boats.API.Configurations.Entities
{
    public class BoatConfiguration : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.HasData(
                new Boat
                {
                    Id = Guid.NewGuid(),
                    Name = "TestingBoat",
                    County = "Royal Palm Beach",
                    State = "Florida",
                    Zipcode = "33411",
                    JobTitle = "Cleaner",
                    JobDesciption = "Boat is dirty",
                    Date = "1/15/2023",
                    Amount = 50
                },
                new Boat
                {
                    Id = Guid.NewGuid(),
                    Name = "TestingBoatTwo",
                    County = "Royal Palm Beach",
                    State = "Florida",
                    Zipcode = "33411",
                    JobTitle = "Washer",
                    JobDesciption = "Boat is Still dirty",
                    Date = "1/16/2023",
                    Amount = 75
                }
            ) ;
        }
    }
}
