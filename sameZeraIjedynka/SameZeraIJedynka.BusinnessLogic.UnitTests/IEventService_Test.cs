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
using Xunit;



namespace SameZeraIJedynka.BusinnessLogic.UnitTests
{
    public class IEventService_Test

    {
        [Fact]
        public async Task Add_Should_ReturnNewEventId_WithImage()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            var imageMock = new Mock<IFormFile>();
            imageMock.Setup(i => i.Length).Returns(100); // Set image length (change as needed)

            var addEventRequest = new EventModel
            {
                // Set event properties (change as needed)
            };

            // Set up the mock repository's AddEvent() method to return a new EventId
            mockEventRepository.Setup(r => r.AddEvent(It.IsAny<Event>())).ReturnsAsync(1);

            // Act
            var result = await service.Add(addEventRequest, imageMock.Object);

            // Assert
            Assert.Equal(1, result); // Ensure the method returns the expected new EventId
            mockEventRepository.Verify(r => r.AddEvent(It.IsAny<Event>()), Times.Once); // Verify that the AddEvent method was called once with any Event argument
        }

        [Fact]
        public async Task Add_Should_ReturnNewEventId_WithoutImage()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            IFormFile image = null; // Null image

            var addEventRequest = new EventModel
            {
                // Set event properties (change as needed)
            };

            // Set up the mock repository's AddEvent() method to return a new EventId
            mockEventRepository.Setup(r => r.AddEvent(It.IsAny<Event>())).ReturnsAsync(1);

            // Act
            var result = await service.Add(addEventRequest, image);

            // Assert
            Assert.Equal(1, result); // Ensure the method returns the expected new EventId
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
                new Event { /* Event properties here */ },
                new Event { /* Event properties here */ },
                // Add more events as needed for testing different scenarios
            };

            // Set up the mock repository's Get() method to return the prepared events
            mockEventRepository.Setup(r => r.Get()).ReturnsAsync(events.AsQueryable());

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

            // Prepare a list of events to be returned by the mocked repository
            var events = new List<Event>
            {
                new Event { /* Event properties here - Matches the search pattern */ },
                new Event { /* Event properties here - Does not match the search pattern */ },
                // Add more events as needed for testing different scenarios
            };

            // Set up the mock repository's Search() method to return the prepared events
            mockEventRepository.Setup(r => r.Search(searchPattern)).ReturnsAsync(events.AsQueryable());

            // Act
            var result = await service.Search(searchPattern);

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            // Implement your specific assertions based on the expected matching events and non-matching events
        }

        [Fact]
        public async Task Delete_Should_DeleteEvent()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            var eventToDelete = new EventModel { EventId = 1 }; // Create an event model to be deleted (change as needed)

            // Set up the mock repository's GetById() method to return the event to be deleted
            mockEventRepository.Setup(r => r.GetById(eventToDelete.EventId)).ReturnsAsync(new Event());

            // Act
            await service.Delete(eventToDelete);

            // Assert
            mockEventRepository.Verify(r => r.Delete(It.IsAny<Event>()), Times.Once); // Verify that the Delete method was called once with any Event argument
        }

        [Fact]
        public async Task EventDetails_Should_ReturnEvent()
        {
            // Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var service = new EventService(mockEventRepository.Object);

            var eventId = 1; // The event ID to retrieve (change as needed)

            // Prepare an event to be returned by the mocked repository
            var eventDetails = new Event { /* Event properties here */ };

            // Set up the mock repository's GetById() method to return the prepared event
            mockEventRepository.Setup(r => r.GetById(eventId)).ReturnsAsync(eventDetails);

            // Act
            var result = await service.EventDetails(eventId);

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            // Implement your specific assertions based on the expected event details
        }
    }
}
