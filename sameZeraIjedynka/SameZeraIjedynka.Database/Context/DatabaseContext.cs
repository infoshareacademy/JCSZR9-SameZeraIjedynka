using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFavorite>().HasKey(x => new { x.EventId, x.UserId });
            base.OnModelCreating(modelBuilder);

            //Adding values to DB Events data
            modelBuilder.Entity<Event>().HasData(new Event[]
                {new Event
                    { EventId = 1,
                      Name = "Warsztaty artystyczne",
                      Date = new DateTime(2023, 12, 06, 12, 00, 00),
                      Organizer = "Fundacja Dla Dziecka",
                      Place = "Gdansk, Zielona 23",
                      Price = 0,
                      Capacity = 100,
                      Target = TargetEnum.adults,
                      Description = "Warsztaty rysunku dla dzieci to interaktywne i kreatywne zajęcia, " +
                      "które mają na celu rozwijanie umiejętności plastycznych u najmłodszych. Podczas " +
                      "wydarzenia dzieci będą miały okazję eksperymentować z różnymi technikami rysunku i" +
                      " tworzyć własne unikalne dzieła sztuki, pod opieką doświadczonych instruktorów. Warsztaty " +
                      "stwarzają przyjazną i inspirującą atmosferę, sprzyjającą rozwijaniu wyobraźni i twórczych " +
                      "umiejętności dzieci.",
                      ImagePath = "/assets/img/1.jpg"
                    },
                    new Event
                    {
                        EventId = 2,
                        Name = "Konferencja IT",
                        Date = new DateTime(2023, 09, 16, 12, 00, 00),
                        Organizer = "IT4U",
                        Place = "Gdynia, Zielona 31",
                        Price = 10,
                        Capacity = 1200,
                        Target = TargetEnum.all,
                        Description = "Zlot programistów IT to coroczne spotkanie branżowe, gromadzące pasjonatów " +
                        "programowania i specjalistów z różnych dziedzin informatyki. Podczas tego wydarzenia programiści " +
                        "mają możliwość uczestnictwa w interesujących prezentacjach, warsztatach i panelach dyskusyjnych, " +
                        "które pozwalają na zdobycie wiedzy, dzielenie się doświadczeniami oraz nawiązywanie cennych kontaktów" +
                        " z innymi profesjonalistami. Zlot programistów to także doskonała okazja do aktualizacji wiedzy z" +
                        " najnowszych trendów technologicznych oraz do odkrywania nowych możliwości i wyzwań w dziedzinie " +
                        "informatyki.",
                        ImagePath = "/assets/img/2.jpg"
                    },
                    new Event
                    {
                        EventId = 3,
                        Name = "Koncert rockowy",
                        Date = new DateTime(2023, 12, 01, 19, 30, 00),
                        Organizer = "Klub Uszko",
                        Place = "Gdańsk, Czerwona 1",
                        Price = 0,
                        Capacity = 200,
                        Target = TargetEnum.all,
                        Description = "Koncert pop to niezapomniane muzyczne doświadczenie, podczas którego artyści prezentują" +
                        " najnowsze hity i energetyczne występy. To wyjątkowa okazja dla fanów muzyki pop, by zanurzyć się w" +
                        " dynamicznej atmosferze i świętować wspólnie z ulubionymi artystami. Koncerty pop przyciągają tłumy" +
                        " entuzjastów, którzy mogą wspólnie śpiewać, tańczyć i delektować się niezapomnianymi chwilami pełnymi" +
                        " emocji i rytmu.",
                        ImagePath = "/assets/img/3.jpg"
                    },
                    new Event
                    {
                        EventId = 4,
                        Name = "Turniej piłkarski",
                        Date = new DateTime(2023, 10, 12, 10, 00, 00),
                        Organizer = "Liceum nr 2 w Sopocie",
                        Place = "Sopot, Zolta 5",
                        Price = 0,
                        Capacity = 40,
                        Target = TargetEnum.kids,
                        Description = "Zapraszamy dzieci i młodych piłkarzy do udziału w emocjonującym turnieju piłkarskim," +
                        " gdzie będą miały okazję rywalizować, rozwijać swoje umiejętności i cieszyć się sportowym duchem " +
                        "współzawodnictwa. Ten niezapomniany turniej zapewni dzieciom nie tylko wspaniałą zabawę, ale także " +
                        "możliwość spotkania rówieśników, nawiązania nowych przyjaźni oraz tworzenia piłkarskich wspomnień " +
                        "na całe życie.",
                        ImagePath = "/assets/img/4.jpg"
                    },
                    new Event
                    {
                        EventId = 5,
                        Name = "Kącik eksperta",
                        Date = new DateTime(2023, 08, 22, 15, 00, 00),
                        Organizer = "Ewa Maj",
                        Place = "Gdansk, Czerwona 123",
                        Price = 100,
                        Capacity = 70,
                        Target = TargetEnum.grandpas,
                        Description = "Profesjonanle porady prawne i pomoc doradcza w zakresie finansów. Wpadnij i pozbądź " +
                        "się swoich problemów!",
                        ImagePath = "/assets/img/5.jpg"
                    },
                    new Event
                    {
                        EventId = 6,
                        Name = "Spotkanie podróżnicze",
                        Date = new DateTime(2023, 08, 29, 15, 00, 00),
                        Organizer = "Ewa Maj",
                        Place = "Gdansk, Niebieska 20",
                        Price = 10,
                        Capacity = 700,
                        Target = TargetEnum.adults,
                        Description = "Zapraszamy serdecznie na niezwykłe \"Spotkanie podróżnicze\" z Ewą Maj, podczas którego " +
                        "będzie miała okazję podzielić się swoją inspirującą historią podróży, w tym niezapomnianym wyjazdem do" +
                        " urokliwego Mozambiku. Przygotujcie się na fascynujące opowieści, piękne zdjęcia i ciekawe anegdoty, " +
                        "które przeniosą Was w egzotyczne zakątki świata i rozbudzą Waszą pasję do odkrywania nowych miejsc.",
                        ImagePath = "/assets/img/6.jpg"
                    }
            });

            //Adding values to DB Users data
            modelBuilder.Entity<User>().HasData(new User[]
                        {new User
                            {
                                UserId=1,
                                Name="AAA",
                                Password="BBB"
                              //  UsersFavorites=
                            },
                        new User
                            {
                                UserId=2,
                                Name="BBB",
                                Password="CCC"
                              //UsersFavorites=
                            },
                        new User
                            {
                                UserId=3,
                                Name="CCC",
                                Password="DDD"
                              //  UsersFavorites=
                            }
            });

            //Adding values to DB Users data
            modelBuilder.Entity<UserFavorite>().HasData(new UserFavorite[]
                        { new UserFavorite
                            {   EventId = 1,

                                UserId = 1,

                            },
                            new UserFavorite
                            {   EventId = 2,

                                UserId = 2,

                            }

              });
        }










        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorite> Favorites { get; set; }
    }

}
