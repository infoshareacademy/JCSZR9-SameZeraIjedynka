using Moq;
using SameZeraIjedynka.BusinnessLogic.Services;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SameZeraIJedynka.BusinnessLogic.UnitTests
{
    public class HomeService_Tests
    {
        [Fact]
        public async Task GetHomeEvents_Should_ReturnListOfEvents()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new HomeService(mockEventRepository.Object);

            // Prepare a list of events to be returned by the mocked repository
            var events = new List<Event>
            {
                new Event {  EventId = 1,
                      Name = "Warsztaty artystyczne",
                      Date = new DateTime(2023, 12, 06, 12, 00, 00),
                      Organizer = "Fundacja Dla Dziecka",
                      Place = "Gdansk, Zielona 23",
                      Price = 0,
                      Capacity = 100,
                      Target = TargetEnum.all,
                      Description = "Warsztaty rysunku dla dzieci to interaktywne i kreatywne zajęcia, " +
                      "które mają na celu rozwijanie umiejętności plastycznych u najmłodszych. Podczas " +
                      "wydarzenia dzieci będą miały okazję eksperymentować z różnymi technikami rysunku i" +
                      " tworzyć własne unikalne dzieła sztuki, pod opieką doświadczonych instruktorów. Warsztaty " +
                      "stwarzają przyjazną i inspirującą atmosferę, sprzyjającą rozwijaniu wyobraźni i twórczych " +
                      "umiejętności dzieci.",
                      ImagePath = "/assets/img/1.jpg"},
                new Event { /* Event properties here */ },
                // Add more events as needed for testing different scenarios
            };

            // Set up the mock repository's GetHomeEvents() method to return the prepared events
            mockEventRepository.Setup(r => r.GetHomeEvents()).ReturnsAsync(events.AsQueryable());

            // Act
            var result = await service.GetHomeEvents();

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            Assert.Equal(events.Count, result.Count); // Ensure the number of returned events matches the number of prepared events
            // Implement your specific assertions to check the properties of returned events, if needed
        }

        [Fact]
        public async Task GetHomeEvents_Should_ReturnEmptyList_WhenNoEvents()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new HomeService(mockEventRepository.Object);

            // Prepare an empty list of events to be returned by the mocked repository
            var events = new List<Event>();

            // Set up the mock repository's GetHomeEvents() method to return the prepared empty list
            mockEventRepository.Setup(r => r.GetHomeEvents()).ReturnsAsync(events.AsQueryable());

            // Act
            var result = await service.GetHomeEvents();

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            Assert.Empty(result); // Ensure the returned list is empty
        }
    }
}