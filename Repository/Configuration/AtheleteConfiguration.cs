using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration
{
    public class AtheleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder) => builder.HasData(
            new Athlete
            {
                Age = 35,
                Country = "BR",
                Name = "Audrey",
                SurName = "Hughes",
                Id = Guid.NewGuid(),
                MaximumCalories = 1000
            },
            new Athlete
            {
                Age = 20,
                Country = "CO",
                Name = "Sue",
                SurName = "Sharp",
                Id = Guid.NewGuid(),
                MaximumCalories = 2500
            },
            new Athlete
            {
                Age = 40,
                Country = "BR",
                Name = "Joseph",
                SurName = "Sutherland",
                Id = Guid.NewGuid(),
                MaximumCalories = 800
            });
    }
}
