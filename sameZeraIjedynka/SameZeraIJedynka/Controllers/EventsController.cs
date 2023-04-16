using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Models;
using System.Reflection;
using SameZeraIJedynka.Services;

namespace SameZeraIJedynka.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService _eventService;
        public EventsController()
        {
            _eventService = new EventService();
        }
        // GET: EventController
        public ActionResult Index()
        {
            var model = _eventService.GetAll();
            return View(model);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            var model = _eventService.GetAll();
            return View(model);
        }

        // GET: EventController/Create
        public ActionResult Create(Event model)
        {
            try
            {
                _eventService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventtController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _eventService.GetbyId(id);
            return View(model);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Event model)
        {
            try
            {
                _eventService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _eventService.GetbyId(id);
            return View(model);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Event model)
        {
            try
            {
                _eventService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
