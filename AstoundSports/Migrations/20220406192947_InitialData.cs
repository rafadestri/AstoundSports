using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstoundSports.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("22ab4e05-4acd-4235-9b99-1d012cd06bb4"));

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("2e235ac6-a3aa-40a4-a5eb-38a36afe4378"));

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("74c00bd6-e657-49af-ae43-59bfc10c446b"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("56e8d823-f384-4005-a4ed-27c4d0156fc0"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("998c6595-5bd1-45c4-b271-83a840b3b656"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("c6c273b0-0ee3-4fd3-aa07-d1c781df1c61"));

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "AthleteId", "Age", "Country", "MaximumCalories", "Name", "SurName" },
                values: new object[,]
                {
                    { new Guid("1147a2a4-b23f-4a7e-805e-92eb9c9b7098"), 35, "BR", 100, "Audrey ", "Hughes" },
                    { new Guid("ab617dfa-5466-4a9b-a970-fcc7378be30e"), 20, "CO", 250, "Sue ", "Sharp" },
                    { new Guid("4cd5757a-6d6c-47aa-919e-67cef680dd36"), 40, "BR", 80, "Joseph ", "Sutherland" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "CaloriesBurntByMinute", "Duration", "Name", "NumberOfPlayers" },
                values: new object[,]
                {
                    { new Guid("4332840c-d45c-47c5-b27e-c29e325c9cc4"), 10, 90, "Soccer", 24 },
                    { new Guid("8642cadb-b70a-407d-ba05-022f9306bba3"), 10, 48, "Basket", 10 },
                    { new Guid("3e2eb6b9-0eae-4d97-b7cb-27c8beff4b86"), 15, 30, "Table Tenis", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("1147a2a4-b23f-4a7e-805e-92eb9c9b7098"));

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("4cd5757a-6d6c-47aa-919e-67cef680dd36"));

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "AthleteId",
                keyValue: new Guid("ab617dfa-5466-4a9b-a970-fcc7378be30e"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("3e2eb6b9-0eae-4d97-b7cb-27c8beff4b86"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("4332840c-d45c-47c5-b27e-c29e325c9cc4"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("8642cadb-b70a-407d-ba05-022f9306bba3"));

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
    }
}
