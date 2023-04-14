using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Services;

namespace SameZeraIJedynka.Controllers
{
    public class UlubioneController : Controller
    {
        private EventService _eventService;

        public UlubioneController()
        {
            _eventService = new EventService();
        }
        // GET: UlubioneController
        public ActionResult Index()
        {
            var model = _eventService.isFavorite();
            return View(model);
        }

        // GET: UlubioneController/Details/5
        public ActionResult Details()
        {
            var model = _eventService.allEvents();
            return View(model);
        }

        // GET: UlubioneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UlubioneController/Create
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

        // GET: UlubioneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UlubioneController/Edit/5
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

        // GET: UlubioneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UlubioneController/Delete/5
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
