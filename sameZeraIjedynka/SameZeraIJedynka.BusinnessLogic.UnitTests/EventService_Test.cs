using Microsoft.AspNetCore.Http;
using Moq;
using SameZeraIJedynka.BusinnessLogic.Models;
using SameZeraIJedynka.BusinnessLogic.Services;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIJedynka.BusinnessLogic.UnitTests
{
    public class EventService_Test
    {
        [Fact]
        public async Task Add_Should_AddEvent_WithImage()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            var imageMock = new Mock<IFormFile>();
            imageMock.Setup(i => i.Length).Returns(100); // Set image length (change as needed)
            imageMock.Setup(i => i.FileName).Returns("testimage.png");

            var addEventRequest = new EventModel
            {
                EventId = 1,
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
                ImagePath = "/assets/img/1.jpg"
            };

            // Set up the mock repository's AddEvent() method to return a new EventId
            mockEventRepository.Setup(r => r.AddEvent(It.IsAny<Event>())).ReturnsAsync(1);

            // Act
            var result = await service.Add(addEventRequest, imageMock.Object);

            // Assert
            Assert.Equal(1, result); // Ensure the method returns the expected new EventId
            Assert.NotNull(addEventRequest.ImagePath); // Ensure the ImagePath is not null after adding the event with an image
            mockEventRepository.Verify(r => r.AddEvent(It.IsAny<Event>()), Times.Once); // Verify that the AddEvent method was called once with any Event argument
        }

        [Fact]
        public async Task Add_Should_AddEvent_WithoutImage()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            IFormFile image = null; // Null image

            var addEventRequest = new EventModel
            {
                EventId = 1,
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
                ImagePath = "/assets/img/1.jpg"
                // Setting it to null as the method will generate the path based on the image
            };

            // Set up the mock repository's AddEvent() method to return a new EventId
            mockEventRepository.Setup(r => r.AddEvent(It.IsAny<Event>())).ReturnsAsync(1);

            // Act
            var result = await service.Add(addEventRequest, image);

            // Assert
            Assert.Equal(1, result); // Ensure the method returns the expected new EventId
            Assert.NotNull(addEventRequest.ImagePath); // Ensure the ImagePath is not null after adding the event without an image
            mockEventRepository.Verify(r => r.AddEvent(It.IsAny<Event>()), Times.Once); // Verify that the AddEvent method was called once with any Event argument
        }

        [Theory]
        [InlineData("time_left")]
        [InlineData("time_left_desc")]
        [InlineData("price")]
        [InlineData("price_desc")]
        [InlineData(null)] // Test with null sortOption
        public async Task Index_Should_ReturnSortedEvents(string sortOption)
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            // Prepare a list of events to be returned by the mocked repository
            var events = new List<Event>
            {
                new Event { EventId = 1,
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
                      ImagePath = "/assets/img/1.jpg" },
                new Event { /* Event properties here */ },
                // Add more events as needed for testing different scenarios
            };

            // Set up the mock repository's Get() method to return the prepared events
            var eventsQueryable = events.AsQueryable();
            mockEventRepository.Setup(r => r.Get()).ReturnsAsync(eventsQueryable);

            // Act
            var result = await service.Index(sortOption);

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            // Implement your specific assertions based on the sortOption and expected order of events
        }

        [Fact]
        public async Task Search_Should_ReturnMatchingEvents()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            var searchPattern = "search_term"; // The pattern to search for (change as needed)

        }
    }
}
