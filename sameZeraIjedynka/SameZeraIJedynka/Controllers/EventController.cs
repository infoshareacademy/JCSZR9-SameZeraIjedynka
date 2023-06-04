using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SameZeraIJedynka.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController()
        {
            _eventService = new EventService();
        }

        //private readonly Event _context;

        //public EventController(Event context)
        //{
        //    _context = context;
        //}

        // GET: EventController
        [Route("")]
        public ActionResult Index()
        {
            var model = _eventService.ABC();
            return View(model);
        }

        // GET: EventController/Details/5
        //  [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _eventService.GetEventById(id);
            return View(model);
        }

        // GET: EventController/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create(EventModel model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return View(model);
                //}
                _eventService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
    }

    // POST: EventController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
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
}
}
