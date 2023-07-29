﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SameZeraIjedynka.Database.Context;

#nullable disable

namespace SameZeraIjedynka.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Capacity = 100,
                            Date = new DateTime(2023, 12, 6, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Warsztaty rysunku dla dzieci to interaktywne i kreatywne zajęcia, które mają na celu rozwijanie umiejętności plastycznych u najmłodszych. Podczas wydarzenia dzieci będą miały okazję eksperymentować z różnymi technikami rysunku i tworzyć własne unikalne dzieła sztuki, pod opieką doświadczonych instruktorów. Warsztaty stwarzają przyjazną i inspirującą atmosferę, sprzyjającą rozwijaniu wyobraźni i twórczych umiejętności dzieci.",
                            ImagePath = "/assets/img/1.jpg",
                            Name = "Warsztaty artystyczne",
                            Organizer = "Fundacja Dla Dziecka",
                            Place = "Gdansk, Zielona 23",
                            Price = 0,
                            Target = 3,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 2,
                            Capacity = 1200,
                            Date = new DateTime(2023, 9, 16, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zlot programistów IT to coroczne spotkanie branżowe, gromadzące pasjonatów programowania i specjalistów z różnych dziedzin informatyki. Podczas tego wydarzenia programiści mają możliwość uczestnictwa w interesujących prezentacjach, warsztatach i panelach dyskusyjnych, które pozwalają na zdobycie wiedzy, dzielenie się doświadczeniami oraz nawiązywanie cennych kontaktów z innymi profesjonalistami. Zlot programistów to także doskonała okazja do aktualizacji wiedzy z najnowszych trendów technologicznych oraz do odkrywania nowych możliwości i wyzwań w dziedzinie informatyki.",
                            ImagePath = "/assets/img/2.jpg",
                            Name = "Konferencja IT",
                            Organizer = "IT4U",
                            Place = "Gdynia, Zielona 31",
                            Price = 10,
                            Target = 1,
                            UserId = 2
                        },
                        new
                        {
                            EventId = 3,
                            Capacity = 200,
                            Date = new DateTime(2023, 12, 1, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Koncert pop to niezapomniane muzyczne doświadczenie, podczas którego artyści prezentują najnowsze hity i energetyczne występy. To wyjątkowa okazja dla fanów muzyki pop, by zanurzyć się w dynamicznej atmosferze i świętować wspólnie z ulubionymi artystami. Koncerty pop przyciągają tłumy entuzjastów, którzy mogą wspólnie śpiewać, tańczyć i delektować się niezapomnianymi chwilami pełnymi emocji i rytmu.",
                            ImagePath = "/assets/img/3.jpg",
                            Name = "Koncert rockowy",
                            Organizer = "Klub Uszko",
                            Place = "Gdańsk, Czerwona 1",
                            Price = 0,
                            Target = 1,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 4,
                            Capacity = 40,
                            Date = new DateTime(2023, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zapraszamy dzieci i młodych piłkarzy do udziału w emocjonującym turnieju piłkarskim, gdzie będą miały okazję rywalizować, rozwijać swoje umiejętności i cieszyć się sportowym duchem współzawodnictwa. Ten niezapomniany turniej zapewni dzieciom nie tylko wspaniałą zabawę, ale także możliwość spotkania rówieśników, nawiązania nowych przyjaźni oraz tworzenia piłkarskich wspomnień na całe życie.",
                            ImagePath = "/assets/img/4.jpg",
                            Name = "Turniej piłkarski",
                            Organizer = "Liceum nr 2 w Sopocie",
                            Place = "Sopot, Zolta 5",
                            Price = 0,
                            Target = 0,
                            UserId = 2
                        },
                        new
                        {
                            EventId = 5,
                            Capacity = 70,
                            Date = new DateTime(2023, 8, 22, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Profesjonanle porady prawne i pomoc doradcza w zakresie finansów. Wpadnij i pozbądź się swoich problemów!",
                            ImagePath = "/assets/img/5.jpg",
                            Name = "Kącik eksperta",
                            Organizer = "Ewa Maj",
                            Place = "Gdansk, Czerwona 123",
                            Price = 100,
                            Target = 2,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 6,
                            Capacity = 700,
                            Date = new DateTime(2023, 8, 29, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zapraszamy serdecznie na niezwykłe \"Spotkanie podróżnicze\" z Ewą Maj, podczas którego będzie miała okazję podzielić się swoją inspirującą historią podróży, w tym niezapomnianym wyjazdem do urokliwego Mozambiku. Przygotujcie się na fascynujące opowieści, piękne zdjęcia i ciekawe anegdoty, które przeniosą Was w egzotyczne zakątki świata i rozbudzą Waszą pasję do odkrywania nowych miejsc.",
                            ImagePath = "/assets/img/6.jpg",
                            Name = "Spotkanie podróżnicze",
                            Organizer = "Ewa Maj",
                            Place = "Gdansk, Niebieska 20",
                            Price = 10,
                            Target = 3,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "aaa@gmail.com",
                            Name = "AAA",
                            Password = "3NtwQQmkVHhLgSKdKwXzaGkudYv6M8th0Ewbk3kbAnM="
                        },
                        new
                        {
                            UserId = 2,
                            Email = "bbb@gmail.com",
                            Name = "BBB",
                            Password = "jFX/laZg83ywXmROdpHmxmWT9FPLLLqk1kqlm0CugDI="
                        },
                        new
                        {
                            UserId = 3,
                            Email = "ccc@gmail.com",
                            Name = "CCC",
                            Password = "TF+R2EJPlSms9xGNEzqT0qbKsZFBw1wwZIN+bdV7maM="
                        });
                });

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.UserFavorite", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.UserFavorite", b =>
                {
                    b.HasOne("SameZeraIjedynka.Database.Entities.Event", "Event")
                        .WithMany("EventFavorites")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SameZeraIjedynka.Database.Entities.User", "User")
                        .WithMany("UsersFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.Event", b =>
                {
                    b.Navigation("EventFavorites");
                });

            modelBuilder.Entity("SameZeraIjedynka.Database.Entities.User", b =>
                {
                    b.Navigation("UsersFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
