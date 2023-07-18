using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;
using Newtonsoft.Json;
using NuGet.ContentModel;
using SameZeraIJedynka.BusinnessLogic.Services;

namespace SameZeraIJedynka.Controllers
{
    public class EventController : Controller
    {
        private readonly DatabaseContext mvcDbContext;
        private readonly IEventService eventService;

        public EventController(DatabaseContext mvcDbContext, IEventService eventService) 
        {
            this.mvcDbContext = mvcDbContext;
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventModel addEventRequest, IFormFile image)
        {
            var newEventId = await eventService.Add(addEventRequest, image); 

            return RedirectToAction("EventDetails", new { id = newEventId });
        }

		[HttpGet]
		public async Task<IActionResult> Index(string sortOption = null)
		{
			var eventsQuery = await eventService.Index(sortOption);
			var events = await eventsQuery.ToListAsync();

			return View(events);
		}

        [HttpGet]
        public async Task<IActionResult> Search(string searchPattern)
        {
            var eventsQuery = await eventService.Search(searchPattern);

            return View("Index", eventsQuery);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EventModel model)
        {
            await eventService.Delete(model);

            return RedirectToAction("Index");
        }

		[HttpGet]
        public async Task<IActionResult> EventDetails(int id)
		{
            var eventQuery = await eventService.EventDetails(id);

            return View(eventQuery);
		}

	}
    
}
