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

        public ActionResult Favorites()
        {
            var model = _eventService.isFavorite();
            return View(model);
        }

        public ActionResult FavoritesEdit(int id)
        {
            var model = _eventService.ReverseIsFavorite(id);
            return View(model);
        }
    }
}
