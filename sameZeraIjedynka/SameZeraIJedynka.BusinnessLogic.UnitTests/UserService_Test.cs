
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using SameZeraIjedynka.BusinnessLogic.Services;
using SameZeraIjedynka.Database.Repositories;
using SameZeraIjedynka.Database.Entities;

namespace SameZeraIJedynka.BusinnessLogic.UnitTests
{
    public class UserService_Test
    {
        [Theory]
        [InlineData(1, "time_left")]
        [InlineData(1, "time_left_desc")]
        [InlineData(1, "price")]
        [InlineData(1, "price_desc")]
        [InlineData(1, null)]
        public async Task GetFavoriteEvents_Should_ReturnListOfEvents(int userId, string sortOption)
        {
            // Arrange
            var mockUserFavoriteRepository = new Mock<IUserFavoriteRepository>();
            var service = new UserFavoriteService(mockUserFavoriteRepository.Object);

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
            mockUserFavoriteRepository.Setup(r => r.Get()).ReturnsAsync(eventsQueryable);

            // Act
            var result = await service.GetFavoriteEvents(userId, sortOption);

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            // Implement your specific assertions based on the sortOption and expected order of events
        }

        [Fact]
        public async Task AddFavoriteEvent_Should_AddFavoriteEvent()
        {
            // Arrange
            var mockUserFavoriteRepository = new Mock<IUserFavoriteRepository>();
            var service = new UserFavoriteService(mockUserFavoriteRepository.Object);

            int eventIdToAdd = 1; // The event ID to add (change as needed)

            // Act
            await service.AddFavoriteEvent(eventIdToAdd);

            // Assert
            mockUserFavoriteRepository.Verify(r => r.Add(It.IsAny<UserFavorite>()), Times.Once); // Verify that the Add method was called once with any UserFavorite argument
        }

        [Fact]
        public async Task DeleteFavoriteEvent_Should_DeleteFavoriteEvent()
        {
            // Arrange
            var mockUserFavoriteRepository = new Mock<IUserFavoriteRepository>();
            var service = new UserFavoriteService(mockUserFavoriteRepository.Object);

            int eventIdToDelete = 1; // The event ID to delete (change as needed)

            // Prepare a UserFavorite object to be returned by the mocked repository's Find method
            var favoriteEvent = new UserFavorite
            {
                EventId = eventIdToDelete,
                UserId = 2
            };

            // Set up the mock repository's Find method to return the prepared UserFavorite object
            mockUserFavoriteRepository.Setup(r => r.Find(eventIdToDelete)).ReturnsAsync(favoriteEvent);

            // Act
            await service.DeleteFavoriteEvent(eventIdToDelete);

            // Assert
            mockUserFavoriteRepository.Verify(r => r.Delete(It.IsAny<UserFavorite>()), Times.Once); // Verify that the Delete method was called once with any UserFavorite argument
        }

        [Fact]
        public async Task DeleteFavoriteEvent_Should_NotDelete_WhenEventNotFound()
        {
            // Arrange
            var mockUserFavoriteRepository = new Mock<IUserFavoriteRepository>();
            var service = new UserFavoriteService(mockUserFavoriteRepository.Object);

            int eventIdToDelete = 1; // The event ID to delete (change as needed)

            // Set up the mock repository's Find method to return null (event not found)
            mockUserFavoriteRepository.Setup(r => r.Find(eventIdToDelete)).ReturnsAsync((UserFavorite)null);

            // Act
            await service.DeleteFavoriteEvent(eventIdToDelete);

            // Assert
            mockUserFavoriteRepository.Verify(r => r.Delete(It.IsAny<UserFavorite>()), Times.Never); // Verify that the Delete method was never called
        }
    }
}
