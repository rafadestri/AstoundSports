using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder) => builder.HasData(
                new Sport
                {
                    CaloriesBurntByMinute = 10,
                    Duration = 90,
                    Id = Guid.NewGuid(),
                    Name = "Soccer",
                    NumberOfPlayers = 24
                },
                new Sport
                {
                    CaloriesBurntByMinute = 10,
                    Duration = 48,
                    Id = Guid.NewGuid(),
                    Name = "Basket",
                    NumberOfPlayers = 10
                },
                new Sport
                {
                    CaloriesBurntByMinute = 15,
                    Duration = 30,
                    Id = Guid.NewGuid(),
                    Name = "Table Tenis",
                    NumberOfPlayers = 1
                });
    }
}
