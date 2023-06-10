using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;
using Microsoft.EntityFrameworkCore;

namespace SameZeraIJedynka.Controllers
{
    public class UserFavoriteController : Controller
    {
        private readonly DatabaseContext mvcDbContext;

        public UserFavoriteController(DatabaseContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var events = await mvcDbContext.Events.Where(x=>x.EventFavorites.Any(y=>y.UserId ==1)).ToListAsync();

            var events2 = await mvcDbContext.Favorites.Where(x => x.UserId == 2).Select(x => x.Event).ToListAsync();

            var userFavorite = await mvcDbContext.Favorites.ToListAsync();
            return View(events2);
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var newFavorite = new UserFavorite()
            {
                EventId = id,
                UserId = 2
            };
            await mvcDbContext.Favorites.AddAsync(newFavorite);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}


