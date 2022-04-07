using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repository.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Sports");
        }

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
                    { new Guid("f049f5a6-e1f4-4300-8f54-a44b63831a37"), 35, "BR", 1000, "Audrey", "Hughes" },
                    { new Guid("1fdba9a7-58fa-4df3-87ec-59acaa2bcb55"), 20, "CO", 2500, "Sue", "Sharp" },
                    { new Guid("11aa2e81-501e-46f4-a174-6c3dda4a9028"), 40, "BR", 800, "Joseph", "Sutherland" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "CaloriesBurntByMinute", "Duration", "Name", "NumberOfPlayers" },
                values: new object[,]
                {
                    { new Guid("69078b9a-eef0-4161-aeca-097056af10bf"), 10, 90, "Soccer", 24 },
                    { new Guid("30f37dc3-6e2b-4b78-a172-a553d28a43ac"), 10, 48, "Basket", 10 },
                    { new Guid("781f2e75-99bf-4b4a-847a-719f03a495bf"), 15, 30, "Table Tenis", 1 }
                });
        }
    }
}
