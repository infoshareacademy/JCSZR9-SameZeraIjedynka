using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SameZeraIjedynka.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Favorites_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "Date", "Description", "ImagePath", "Name", "Organizer", "Place", "Price", "Target", "UserId" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2023, 12, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), "Warsztaty rysunku dla dzieci to interaktywne i kreatywne zajęcia, które mają na celu rozwijanie umiejętności plastycznych u najmłodszych. Podczas wydarzenia dzieci będą miały okazję eksperymentować z różnymi technikami rysunku i tworzyć własne unikalne dzieła sztuki, pod opieką doświadczonych instruktorów. Warsztaty stwarzają przyjazną i inspirującą atmosferę, sprzyjającą rozwijaniu wyobraźni i twórczych umiejętności dzieci.", "/assets/img/1.jpg", "Warsztaty artystyczne", "Fundacja Dla Dziecka", "Gdansk, Zielona 23", 0, 3, 1 },
                    { 2, 1200, new DateTime(2023, 9, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), "Zlot programistów IT to coroczne spotkanie branżowe, gromadzące pasjonatów programowania i specjalistów z różnych dziedzin informatyki. Podczas tego wydarzenia programiści mają możliwość uczestnictwa w interesujących prezentacjach, warsztatach i panelach dyskusyjnych, które pozwalają na zdobycie wiedzy, dzielenie się doświadczeniami oraz nawiązywanie cennych kontaktów z innymi profesjonalistami. Zlot programistów to także doskonała okazja do aktualizacji wiedzy z najnowszych trendów technologicznych oraz do odkrywania nowych możliwości i wyzwań w dziedzinie informatyki.", "/assets/img/2.jpg", "Konferencja IT", "IT4U", "Gdynia, Zielona 31", 10, 1, 2 },
                    { 3, 200, new DateTime(2023, 12, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), "Koncert pop to niezapomniane muzyczne doświadczenie, podczas którego artyści prezentują najnowsze hity i energetyczne występy. To wyjątkowa okazja dla fanów muzyki pop, by zanurzyć się w dynamicznej atmosferze i świętować wspólnie z ulubionymi artystami. Koncerty pop przyciągają tłumy entuzjastów, którzy mogą wspólnie śpiewać, tańczyć i delektować się niezapomnianymi chwilami pełnymi emocji i rytmu.", "/assets/img/3.jpg", "Koncert rockowy", "Klub Uszko", "Gdańsk, Czerwona 1", 0, 1, 3 },
                    { 4, 40, new DateTime(2023, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Zapraszamy dzieci i młodych piłkarzy do udziału w emocjonującym turnieju piłkarskim, gdzie będą miały okazję rywalizować, rozwijać swoje umiejętności i cieszyć się sportowym duchem współzawodnictwa. Ten niezapomniany turniej zapewni dzieciom nie tylko wspaniałą zabawę, ale także możliwość spotkania rówieśników, nawiązania nowych przyjaźni oraz tworzenia piłkarskich wspomnień na całe życie.", "/assets/img/4.jpg", "Turniej piłkarski", "Liceum nr 2 w Sopocie", "Sopot, Zolta 5", 0, 0, 2 },
                    { 5, 70, new DateTime(2023, 8, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), "Profesjonanle porady prawne i pomoc doradcza w zakresie finansów. Wpadnij i pozbądź się swoich problemów!", "/assets/img/5.jpg", "Kącik eksperta", "Ewa Maj", "Gdansk, Czerwona 123", 100, 2, 1 },
                    { 6, 700, new DateTime(2023, 8, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), "Zapraszamy serdecznie na niezwykłe \"Spotkanie podróżnicze\" z Ewą Maj, podczas którego będzie miała okazję podzielić się swoją inspirującą historią podróży, w tym niezapomnianym wyjazdem do urokliwego Mozambiku. Przygotujcie się na fascynujące opowieści, piękne zdjęcia i ciekawe anegdoty, które przeniosą Was w egzotyczne zakątki świata i rozbudzą Waszą pasję do odkrywania nowych miejsc.", "/assets/img/6.jpg", "Spotkanie podróżnicze", "Ewa Maj", "Gdansk, Niebieska 20", 10, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "aaa@gmail.com", "AAA", "3NtwQQmkVHhLgSKdKwXzaGkudYv6M8th0Ewbk3kbAnM=" },
                    { 2, "bbb@gmail.com", "BBB", "jFX/laZg83ywXmROdpHmxmWT9FPLLLqk1kqlm0CugDI=" },
                    { 3, "ccc@gmail.com", "CCC", "TF+R2EJPlSms9xGNEzqT0qbKsZFBw1wwZIN+bdV7maM=" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
