﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Services;
using System.Reflection;

namespace SameZeraIJedynka.Controllers
{
    public class EventController : Controller
    {
        private readonly DatabaseContext _dbContext;
    

        private readonly EventService _eventService;

        public EventController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _eventService = new EventService(_dbContext);
        }

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
