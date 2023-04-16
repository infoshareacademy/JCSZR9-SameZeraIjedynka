using SameZeraIJedynka.Models;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;

namespace SameZeraIJedynka.Services;

public class EventsService : Controller
{
    private static int _idCounter = 5;
    private static List<Event> _events =
        new List<Event>
        {
            new Event
            {
                Id = 1,
                Name= "Chris",
                //Surname="Muster",
                //BirthDate = new DateTime(2013, 12, 31),
            },
             new Event
            {
                Id = 2,
                Name= "Sam",
                //Surname="Muste",
                //BirthDate = new DateTime(2000, 12, 31),
            },
              new Event
            {
                Id = 3,
                Name= "Ada",
                //Surname="Musterma",
                //BirthDate = new DateTime(1990, 12, 31),
            },
               new Event
            {
                Id = 4,
                Name= "Michel",
                //Surname="Musterdem",
                //BirthDate = new DateTime(1980, 12, 31),
            },
                new Event
            {
                Id = 5,
                Name= "Christopf",
                //Surname="Musters",
                //BirthDate = new DateTime(1970, 12, 31),
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


    public void Create(Event event)
    {
        event.Id = GetNextId();
        _events.Add(event);
    }

    public void Update(Event model)
    {
        var event = GetbyId(model.Id);

        event.Name = model.Name;
        participant.Surname = model.Surname;
        participant.BirthDate = model.BirthDate;
    }

    public void Delete(int id)
    {
        _participants.Remove(GetbyId(id));

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
