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
                      Name = "Event1",
                      Date = new DateTime(2023,10,12),
                      Organizer = "Organizer1",
                      Place = "Gdansk, Zielona 23",
                      Price = 0,
                      Capacity = 100,
                      Target = TargetEnum.adults
                    },
                    new Event
                    {
                        EventId = 2,
                        Name = "Event2",
                        Date = new DateTime(2024, 09, 22),
                        Organizer = "Organizer2",
                        Place = "Gdynia, Zielona 31",
                        Price = 10,
                        Capacity = 1200,
                        Target = TargetEnum.all
                    },
                    new Event
                    {
                        EventId = 3,
                        Name = "Event3",
                        Date = new DateTime(2023, 05, 22),
                        Organizer = "Organizer3",
                        Place = "Gdańsk, Czerwona 1",
                        Price = 0,
                        Capacity = 200,
                        Target = TargetEnum.all
                    },
                    new Event
                    {
                        EventId = 4,
                        Name = "Event4",
                        Date = new DateTime(2023, 05, 05),
                        Organizer = "Organizer4",
                        Place = "Sopot, Zolta 5",
                        Price = 0,
                        Capacity = 40,
                        Target = TargetEnum.kids
                    },
                    new Event
                    {
                        EventId = 5,
                        Name = "Event5",
                        Date = new DateTime(2023, 08, 12),
                        Organizer = "Organizer5",
                        Place = "Gdansk, Czerwona 123",
                        Price = 100,
                        Capacity = 70,
                        Target = TargetEnum.grandpas
                    },
                    new Event
                    {
                        EventId = 6,
                        Name = "Event6",
                        Date = new DateTime(2023, 07, 05),
                        Organizer = "Organizer4",
                        Place = "Gdansk, Niebieska 20",
                        Price = 10,
                        Capacity = 700,
                        Target = TargetEnum.adults
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
