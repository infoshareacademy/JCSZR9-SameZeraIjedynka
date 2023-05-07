using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Services;

namespace SameZeraIJedynka.Controllers
{
    public class FavoriteController : Controller
    {
        private EventService _eventService;

        public FavoriteController()
        {
            _eventService = new EventService();
        }
        // GET: FavoriteController

        public ActionResult Index()
        {
            var model = _eventService.isFavorite();
            return View(model);
        }

        // GET: FavoriteController/Details/5
        public ActionResult Details(int id)
        {
            var model = _eventService.allEvents();
            return View(model);
        }

        // GET: FavoriteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoriteController/Create
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

        // GET: FavoriteController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _eventService.GetById(id);
            return View();
        }

        // POST: FavoriteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventModel model)
        {
            try
            {
                _eventService.Update(model,id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FavoriteController/Delete/5
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
