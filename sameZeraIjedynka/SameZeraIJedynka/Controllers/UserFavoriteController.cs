using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.BusinnessLogic.Models;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Repositories;
using SameZeraIjedynka.BusinnessLogic.Services;

namespace SameZeraIJedynka.Controllers
{
    public class UserFavoriteController : Controller
    {
        private readonly DatabaseContext mvcDbContext;
        private readonly IUserFavoriteService userFavoriteService;

        public UserFavoriteController(DatabaseContext mvcDbContext, IUserFavoriteService userFavoriteService)
        {
            this.mvcDbContext = mvcDbContext;
            this.userFavoriteService = userFavoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOption = null)
        {
            var events = await userFavoriteService.GetFavoriteEvents(2, sortOption);

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


