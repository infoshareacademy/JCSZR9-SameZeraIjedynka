using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.BusinnessLogic.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using SameZeraIJedynka.BusinnessLogic.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SameZeraIJedynka
{
    public class EventServiceTest // zmieniæ nazwê
    {
        [Fact]
        public async Task AddValidEventModelAddsEventToContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var eventService = new EventService(context);

                var addEventRequest = new EventModel
                {
                    EventId = 7,
                    Name = "Test Event",
                    Date = DateTime.Now,
                    Organizer = "Test Organizer",
                    Place = "Test Place",
                    Price = 999,
                    Capacity = 50,
                    Target = TargetEnum.all,
                    Description = "Test Description",
                    ImagePath = "test-image.jpg"
                };

                // Act
                await eventService.Add(addEventRequest);

                // Assert
                var addedEvent = await context.Events.FirstOrDefaultAsync(e => e.EventId == 7);
                Assert.NotNull(addedEvent);
                Assert.Equal(addEventRequest.Name, addedEvent.Name);
                Assert.Equal(addEventRequest.Date, addedEvent.Date);
                Assert.Equal(addEventRequest.Organizer, addedEvent.Organizer);
                Assert.Equal(addEventRequest.Place, addedEvent.Place);
                Assert.Equal(addEventRequest.Price, addedEvent.Price);
                Assert.Equal(addEventRequest.Capacity, addedEvent.Capacity);
                Assert.Equal(addEventRequest.Target, addedEvent.Target);
                Assert.Equal(addEventRequest.Description, addedEvent.Description);
                Assert.Equal(addEventRequest.ImagePath, addedEvent.ImagePath);
            }
        }

        [Fact]
        public async Task SearchExistingEventReturnsMatchingEvent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var eventService = new EventService(context);

                var eventsData = new List<Event>
            {
                new Event
                {
                    EventId = 1,
                    Name = "Warsztaty artystyczne",
                    Date = new DateTime(2023, 12, 06, 12, 00, 00),
                    Organizer = "Fundacja Dla Dziecka",
                    Place = "Gdansk, Zielona 23",
                    Price = 0,
                    Capacity = 100,
                    Target = TargetEnum.all,
                    Description = "Warsztaty rysunku dla dzieci...",
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
                    Target = TargetEnum.adults,
                    Description = "Zlot programistów IT...",
                    ImagePath = "/assets/img/2.jpg"
                },
                new Event
                {
                    EventId = 3,
                    Name = "Koncert rockowy",
                    Date = new DateTime(2023, 12, 01, 19, 30, 00),
                    Organizer = "Klub Uszko",
                    Place = "Gdañsk, Czerwona 1",
                    Price = 0,
                    Capacity = 200,
                    Target = TargetEnum.adults,
                    Description = "Koncert pop to niezapomniane muzyczne doœwiadczenie...",
                    ImagePath = "/assets/img/3.jpg"
                }
            };

                await context.Events.AddRangeAsync(eventsData);
                await context.SaveChangesAsync();

                var searchPattern = "Konferencja IT";

                // Act
                var result = await eventService.Search(searchPattern);

                // Assert
          
                Assert.Equal(eventsData[1].EventId, result[0].EventId);
                Assert.Equal(eventsData[1].Name, result[0].Name);
                Assert.Equal(eventsData[1].Date, result[0].Date);
                Assert.Equal(eventsData[1].Organizer, result[0].Organizer);
                Assert.Equal(eventsData[1].Place, result[0].Place);
                Assert.Equal(eventsData[1].Price, result[0].Price);
                Assert.Equal(eventsData[1].Capacity, result[0].Capacity);
                Assert.Equal(eventsData[1].Target, result[0].Target);
                Assert.Equal(eventsData[1].Description, result[0].Description);
            }
        }
        [Fact]
        public async Task DeleteExistingEventReturnsTrueAndRemovesEvent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                // Dodaj dane testowe
                var eventToDelete = new Event
                {
                    EventId = 1,
                    Name = "Warsztaty artystyczne",
                    Date = new DateTime(2023, 12, 06, 12, 00, 00),
                    Organizer = "Fundacja Dla Dziecka",
                    Place = "Gdansk, Zielona 23",
                    Price = 0,
                    Capacity = 100,
                    Target = TargetEnum.all,
                    Description = "Warsztaty rysunku dla dzieci...",
                    ImagePath = "/assets/img/1.jpg"
                };

                context.Events.Add(eventToDelete);
                await context.SaveChangesAsync();

                var eventService = new EventService(context);

                var eventId = eventToDelete.EventId;

                // Act
                var result = await eventService.Delete(eventId);

                // Assert
                Assert.True(result);

                var deletedEvent = await context.Events.FindAsync(eventId);
                Assert.Null(deletedEvent);
            }
        }
        [Fact]
        public async Task DeleteNonExistingEventReturnsFalse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                var eventService = new EventService(context);

                var nonExistingEventId = 999;

                // Act
                var result = await eventService.Delete(nonExistingEventId);

                // Assert
                Assert.False(result);
            }
        }
    }
}