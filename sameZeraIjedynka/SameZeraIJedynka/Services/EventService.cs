using SameZeraIJedynka.Models;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;

namespace SameZeraIJedynka.Services
{
    public class EventService : Controller
    {
        private static int _idCounter = 5;
        private static List<Event> _events =
            new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name= "Event1",
                    Date = new DateTime(2000, 12, 31),
                    Organizer="Organizer1",
                    Place = "Place1",
                    Price = 100,
                    Capacity = 100,
                    Target = "adults",
                    IsFavourite = true,

                },
                 new Event
                {
                    Id = 2,
                    Name= "Event1",
                    Date = new DateTime(2000, 12, 31),
                    Organizer="Organizer1",
                    Place = "Place1",
                    Price = 100,
                    Capacity = 100,
                    Target = "adults",
                    IsFavourite = true,
                },
                  new Event
                {
                    Id = 3,
                    Name= "Event1",
                    Date = new DateTime(2000, 12, 31),
                    Organizer="Organizer1",
                    Place = "Place1",
                    Price = 100,
                    Capacity = 100,
                    Target = "adults",
                    IsFavourite = true,
                },
                   new Event
                {
                    Id = 4,
                    Name= "Event1",
                    Date = new DateTime(2000, 12, 31),
                    Organizer="Organizer1",
                    Place = "Place1",
                    Price = 100,
                    Capacity = 100,
                    Target = "adults",
                    IsFavourite = true,
                },
                    new Event
                {
                    Id = 5,
                    Name= "Event1",
                    Date = new DateTime(2000, 12, 31),
                    Organizer="Organizer1",
                    Place = "Place1",
                    Price = 100,
                    Capacity = 100,
                    Target = "adults",
                    IsFavourite = true,
                },
            };

        public List<Event> GetAll()
        {
            return _events;
        }

        public Event GetbyId(int id)
        {
            return _events.FirstOrDefault(m => m.Id == id);
        }

        public void Create(Event @event)
        {
            @event.Id = GetNextId();
            _events.Add(@event);
        }
        //public void Create(Event event)
        //{
        //    event.Id = GetNextId();
        //    _events.Add(event);
        //}

        public void Update(Event model)
        {
            var @event = GetbyId(model.Id);
            @model.Name = model.Name;

        }
        //public void Update(Event model)
        //{
        //    var event = GetbyId(model.Id);

        //    event.Name = model.Name;
        //    event.Surname = model.Surname;
        //    event.BirthDate = model.BirthDate;
        //}

        public void Delete(int id)
        {
            _events.Remove(GetbyId(id));

        }

        private int GetNextId()
        {
            _idCounter++;
            return _idCounter;
        }

        internal void Update(object model)
        {
            throw new NotImplementedException();
        }
    
    public IActionResult Index()
        {
            return View();
        }
    }
}
