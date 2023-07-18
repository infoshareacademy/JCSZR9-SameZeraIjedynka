using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;
using Microsoft.AspNetCore.Http;
using SameZeraIjedynka.Database.Repositories;

namespace SameZeraIJedynka.BusinnessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository _eventRepository)
        {
            eventRepository = _eventRepository;
        }

        public async Task<int> Add(EventModel addEventRequest, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string path = Path.Combine(@"wwwroot\assets\img\", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                addEventRequest.ImagePath = "/assets/img/" + fileName;
            }
            else
            {
                string fileName = "placeholder.png";
                addEventRequest.ImagePath = "/assets/img/" + fileName;
            }
            var newEvent = new Event()
            {
                EventId = addEventRequest.EventId,
                Name = addEventRequest.Name,
                Date = addEventRequest.Date,
                Organizer = addEventRequest.Organizer,
                Place = addEventRequest.Place,
                Price = addEventRequest.Price,
                Capacity = addEventRequest.Capacity,
                Target = addEventRequest.Target,
                Description = addEventRequest.Description,
                ImagePath = addEventRequest.ImagePath
            };

            var newEventId = await eventRepository.AddEvent(newEvent);

            return newEventId;
        }

        public async Task<IQueryable<Event>> Index(string sortOption)
        {
            IQueryable<Event> eventsQuery = await eventRepository.Get();

            switch (sortOption)
            {
                case "time_left":
                    eventsQuery = eventsQuery.OrderBy(e => e.Date);
                    break;
                case "time_left_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Date);
                    break;
                case "price":
                    eventsQuery = eventsQuery.OrderBy(e => e.Price);
                    break;
                case "price_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Price);
                    break;
                default:
                    eventsQuery = eventsQuery;
                    break;
            }

            return eventsQuery;
        }

/*        public async Task<List<EventModel>> Search(string searchPattern)
        {
            IQueryable<Event> eventsQuery = context.Events.Where(e => e.Name.Contains(searchPattern));

            var events = await eventsQuery.ToListAsync();

            return events.Select(e => new EventModel
            {
                EventId = e.EventId,
                Name = e.Name,
                Date = e.Date,
                Organizer = e.Organizer,
                Place = e.Place,
                Price = e.Price,
                Capacity = e.Capacity,
                Target = e.Target,
                Description = e.Description
            })
                .ToList();
        }

        public async Task<bool> Delete(int eventId)
        {
            var events = await context.Events.FindAsync(eventId);
            if (events != null)
            {
                context.Events.Remove(events);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Event> EventDetails(int id)
        {
            return await context.Events.FirstOrDefaultAsync(x => x.EventId == id);
        }*/
    }
}
