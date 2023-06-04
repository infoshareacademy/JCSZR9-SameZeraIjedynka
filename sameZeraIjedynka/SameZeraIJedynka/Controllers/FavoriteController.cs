using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.Models;
using SameZeraIJedynka.Services;

namespace SameZeraIJedynka.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly DatabaseContext _dbContext;

        private EventService _eventService;

        public FavoriteController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _eventService = new EventService(_dbContext);
        }
        //public ActionResult Favorites()
        //{
        //    //var model = _eventService.isFavorite();
        //    return View(model);
        //}
        public ActionResult FavoritesEdit(int id)
        {
            var model = _eventService.ReverseIsFavorite(id);
            return View(model);
        }
    }
}
