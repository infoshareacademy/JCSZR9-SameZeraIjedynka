using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.Models;

namespace SameZeraIJedynka.Controllers
{
    public class EventController : Controller
    {
        private readonly DatabaseContext mvcDbContext;  // assign field to what is below

        public EventController(DatabaseContext mvcDbContext)  //constructor //in bracket injected service. Pres dot+CTRL to create an asign field
        {
            this.mvcDbContext = mvcDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventModel addEventRequest)
        {
            var newEvent = new Event()
            {
                EventId = addEventRequest.Id,
                Name = addEventRequest.Name,
                Date = addEventRequest.Date,
                Organizer = addEventRequest.Organizer,
                Place = addEventRequest.Place,
                Price = addEventRequest.Price,
                Capacity = addEventRequest.Capacity,
                Target = addEventRequest.Target
            };
            mvcDbContext.Events.Add(newEvent);
            mvcDbContext.SaveChanges();
            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await mvcDbContext.Events.ToListAsync();
            return View(events);
        }



            [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var events = await mvcDbContext.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if(events != null)
            {
                var viewModel = new EventModel()
                        
                {
                    Id = events.EventId,
                    Name = events.Name,
                    Date = events.Date,
                    Organizer = events.Organizer,
                    Place = events.Place,
                    Price = events.Price,
                    Capacity = events.Capacity,
                    Target = events.Target,
                };
                return await Task.Run(() => View(viewModel));
            }
            return RedirectToAction("Index");
        }
        






    }
}
