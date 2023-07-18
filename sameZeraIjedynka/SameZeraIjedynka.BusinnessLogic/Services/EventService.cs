using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;
using Microsoft.AspNetCore.Http;

namespace SameZeraIJedynka.BusinnessLogic.Services
{
    public class EventService : IEventService
    {
        public EventService(DatabaseContext _context)
        {
            context = _context;
        }

        // TODO: provisional list of events, delete after enabling database
        private static int _idCounter;
        private static List<EventModel> _events = new List<EventModel>
        {
            new EventModel
            {
                  EventId = 1,
                  Name = "Event1",
                  Date = new DateTime(2023,10,12),
                  Organizer = "Organizer1",
                  Place = "Gdansk, Zielona 23",
                  Price = 0,
                  Capacity = 100,
                  Target = TargetEnum.kids,
                  
            },
            new EventModel
            {
                  EventId = 2,
                  Name = "Event2",
                  Date = new DateTime(2024,09,22),
                  Organizer = "Organizer2",
                  Place = "Gdynia, Zielona 31",
                  Price = 10,
                  Capacity = 1200,
                  Target = TargetEnum.all,
                  
            },
            new EventModel
            {
                  EventId = 3,
                  Name = "Event3",
                  Date = new DateTime(2023,05,22),
                  Organizer = "Organizer3",
                  Place = "Gdańsk, Czerwona 1",
                  Price = 0,
                  Capacity = 200,
                  Target = TargetEnum.all,
                  
            },
            new EventModel
            {
                  EventId = 4,
                  Name = "Event4",
                  Date = new DateTime(2023,05,05),
                  Organizer = "Organizer4",
                  Place = "Sopot, Zolta 5",
                  Price = 0,
                  Capacity = 40,
                  Target = TargetEnum.all,
                 
            },
            new EventModel
            {
                  EventId = 5,
                  Name = "Event5",
                  Date = new DateTime(2023,08,12),
                  Organizer = "Organizer5",
                  Place = "Gdansk, Czerwona 123",
                  Price = 100,
                  Capacity = 70,
                  Target = TargetEnum.grandpas,
                 
            },
            new EventModel
            {
                  EventId = 6,
                  Name = "Event6",
                  Date = new DateTime(2023,07,05),
                  Organizer = "Organizer4",
                  Place = "Gdansk, Niebieska 20",
                  Price = 10,
                  Capacity = 700,
                  Target = TargetEnum.adults,
                 
            }
        };
        public object mvcDbContext;
        private readonly DatabaseContext context;

        // return all events
        public List<EventModel> ABC()
        {
            return _events;
        }

        public EventModel GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.EventId == 1);
        }
        public void Create(EventModel eventModel)
        {
            eventModel.EventId = GetNextId();
            _events.Add(eventModel);
        }

        private int GetNextId()
        {
            _idCounter++;

            return _idCounter;
        }

        // return all events
        public List<EventModel> GetUserFavorites(int id)
        {
            var user = context.Users.FirstOrDefault(m => m.UserId == id);
            var userFavorites = user.UsersFavorites.ToList();
            List<EventModel> events = new List<EventModel>();
          
            foreach(var item in userFavorites) //linq
            {
                var favoriteEvent = new EventModel() { Name = item.Event.Name };//dopisac pola
               events.Add(favoriteEvent);
            }

            return events;
              
        }

        public List<EventModel> allEvents()
        {
            return _events;
        }

        public Event GetById(int id)
        {
           
            return context.Events.FirstOrDefault(m => m.EventId == id);
        }


        public List<EventModel> ReverseIsFavorite(int id)
        {
            var events 
                = context.Events.SingleOrDefault(m => m.EventId == id);
            if (events != null)
            {
                //events.IsFavorite = !events.IsFavorite;
                context.SaveChanges();
            }
            return _events.ToList();
        }
    //----------------------------------------------------------------------------------
        public async Task Add(EventModel addEventRequest, IFormFile image)
        {
            if (image != null && image.Length > 0) //można przenieść
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

            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();
        }

        public async Task<List<EventModel>> Search(string searchPattern)
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
        }
    }
}
