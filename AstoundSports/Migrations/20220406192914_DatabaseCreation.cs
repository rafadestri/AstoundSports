using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstoundSports.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    AthleteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumCalories = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.AthleteId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaloriesBurntByMinute = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "AthleteId", "Age", "Country", "MaximumCalories", "Name", "SurName" },
                values: new object[,]
                {
                    { new Guid("2e235ac6-a3aa-40a4-a5eb-38a36afe4378"), 35, "BR", 100, "Audrey ", "Hughes" },
                    { new Guid("22ab4e05-4acd-4235-9b99-1d012cd06bb4"), 20, "CO", 250, "Sue ", "Sharp" },
                    { new Guid("74c00bd6-e657-49af-ae43-59bfc10c446b"), 40, "BR", 80, "Joseph ", "Sutherland" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "CaloriesBurntByMinute", "Duration", "Name", "NumberOfPlayers" },
                values: new object[,]
                {
                    { new Guid("c6c273b0-0ee3-4fd3-aa07-d1c781df1c61"), 10, 90, "Soccer", 24 },
                    { new Guid("56e8d823-f384-4005-a4ed-27c4d0156fc0"), 10, 48, "Basket", 10 },
                    { new Guid("998c6595-5bd1-45c4-b271-83a840b3b656"), 15, 30, "Table Tenis", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
