using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Helpers.Enums;
using System.Reflection;
using SameZeraIJedynka.Helpers.Enums;

namespace SameZeraIJedynka.Services
{
    public class EventService
    {
        public EventService(DatabaseContext _context)
        {
            context = _context;
        }
        // provisional list of events, delete after enabling database
        private static int _idCounter;
        private static List<EventModel> _events = new List<EventModel>
        {
            new EventModel
            {
                  Id = 1,
                  Name = "Event1",
                  Date = new DateTime(2023,10,12),
                  Organizer = "Organizer1",
                  Place = "Gdansk, Zielona 23",
                  Price = 0,
                  Capacity = 100,
                  Target = SameZeraIjedynka.Database.Entities.TargetEnum.kids,
                  
            },
            new EventModel
            {
                  Id = 2,
                  Name = "Event2",
                  Date = new DateTime(2024,09,22),
                  Organizer = "Organizer2",
                  Place = "Gdynia, Zielona 31",
                  Price = 10,
                  Capacity = 1200,
                  Target = SameZeraIjedynka.Database.Entities.TargetEnum.all,
                  
            },
            new EventModel
            {
                  Id = 3,
                  Name = "Event3",
                  Date = new DateTime(2023,05,22),
                  Organizer = "Organizer3",
                  Place = "Gdańsk, Czerwona 1",
                  Price = 0,
                  Capacity = 200,
                  Target =SameZeraIjedynka.Database.Entities.TargetEnum.all,
                  
            },
            new EventModel
            {
                  Id = 4,
                  Name = "Event4",
                  Date = new DateTime(2023,05,05),
                  Organizer = "Organizer4",
                  Place = "Sopot, Zolta 5",
                  Price = 0,
                  Capacity = 40,
                  Target = SameZeraIjedynka.Database.Entities.TargetEnum.all,
                 
            },
            new EventModel
            {
                  Id = 5,
                  Name = "Event5",
                  Date = new DateTime(2023,08,12),
                  Organizer = "Organizer5",
                  Place = "Gdansk, Czerwona 123",
                  Price = 100,
                  Capacity = 70,
                  Target = SameZeraIjedynka.Database.Entities.TargetEnum.grandpas,
                 
            },
            new EventModel
            {
                  Id = 6,
                  Name = "Event6",
                  Date = new DateTime(2023,07,05),
                  Organizer = "Organizer4",
                  Place = "Gdansk, Niebieska 20",
                  Price = 10,
                  Capacity = 700,
                  Target = SameZeraIjedynka.Database.Entities.TargetEnum.adults,
                 
            }
        };
        private readonly DatabaseContext context;

        // return all events
        public List<EventModel> ABC()
        {
            return _events;
        }

        public EventModel GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == 1);
        }
        public void Create(EventModel eventModel)
        {
            eventModel.Id = GetNextId();
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
    }
}
