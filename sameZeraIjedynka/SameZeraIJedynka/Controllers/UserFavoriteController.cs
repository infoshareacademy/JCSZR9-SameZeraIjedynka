using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.BusinnessLogic.Models;
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
        public async Task<IActionResult> Index(string sortOption = null)
        {
            var eventsQuery = mvcDbContext.Favorites.Where(x => x.UserId == 2).Select(x => x.Event);

			switch (sortOption)
			{
				case "time_left":
					eventsQuery = eventsQuery.OrderBy(e => e.Date);
					break;
				case "time_left_desc":
					eventsQuery = eventsQuery.OrderByDescending(e => e.Date);
					break;
				case "price":
					eventsQuery = eventsQuery.OrderBy(e => e.Price);
					break;
				case "price_desc":
					eventsQuery = eventsQuery.OrderByDescending(e => e.Price);
					break;
				default:
					eventsQuery = eventsQuery;
					break;
			}

			var events = await eventsQuery.ToListAsync();

			return View(events);
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
			return RedirectToAction("Index", "UserFavorite");

		}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var newFavorite = new UserFavorite()
            {
                EventId = id,
                UserId = 2
            };
            mvcDbContext.Favorites.Remove(newFavorite); // Change "mvcDbContext.Users" to "mvcDbContext.Favorites"
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }


    }
}


