using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SameZeraIjedynka.Database.Migrations
{
    /// <inheritdoc />
    public partial class changedefaulteventsSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "ImagePath",
                value: "/assets/img/2.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "ImagePath",
                value: "/assets/img/3.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "ImagePath",
                value: "/assets/img/4.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "ImagePath",
                value: "/assets/img/5.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "ImagePath",
                value: "/assets/img/6.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "ImagePath",
                value: "/assest/img/2.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "ImagePath",
                value: "/assest/img/3.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4,
                column: "ImagePath",
                value: "/assest/img/4.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 5,
                column: "ImagePath",
                value: "/assest/img/5.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 6,
                column: "ImagePath",
                value: "/assest/img/6.jpg");
        }
    }
}
