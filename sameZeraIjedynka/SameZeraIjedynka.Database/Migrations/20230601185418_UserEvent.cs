using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SameZeraIjedynka.Database.Migrations
{
    /// <inheritdoc />
    public partial class UserEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "Date", "Name", "Organizer", "Place", "Price", "Target" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event1", "Organizer1", "Gdansk, Zielona 23", 0, 1 },
                    { 2, 1200, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event2", "Organizer2", "Gdynia, Zielona 31", 10, 3 },
                    { 3, 200, new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event3", "Organizer3", "Gdańsk, Czerwona 1", 0, 3 },
                    { 4, 40, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event4", "Organizer4", "Sopot, Zolta 5", 0, 3 },
                    { 5, 70, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event5", "Organizer5", "Gdansk, Czerwona 123", 100, 2 },
                    { 6, 700, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event6", "Organizer4", "Gdansk, Niebieska 20", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "ABC@CDE.com", "AAA", "BBB", "CCC" },
                    { 2, "BCD@CDE.com", "BBB", "CCC", "DDD" },
                    { 3, "BCD@CDE.com", "CCC", "DDD", "EEE" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Favorites",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
