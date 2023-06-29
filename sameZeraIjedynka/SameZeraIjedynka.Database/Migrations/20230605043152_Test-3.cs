using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SameZeraIjedynka.Database.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Name", "Password" },
                values: new object[] { "AAA", "BBB" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Name", "Password" },
                values: new object[] { "BBB", "CCC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Name", "Password" },
                values: new object[] { "CCC", "DDD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { "ABC@CDE.com", "AAA", "BBB", "CCC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { "BCD@CDE.com", "BBB", "CCC", "DDD" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { "BCD@CDE.com", "CCC", "DDD", "EEE" });
        }
    }
}
