using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.BusinnessLogic.Models;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Repositories;
using SameZeraIjedynka.BusinnessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace SameZeraIJedynka.Controllers
{
    public class UserFavoriteController : Controller
    {
        private readonly IUserFavoriteService userFavoriteService;

        public UserFavoriteController(IUserFavoriteService userFavoriteService)
        {
            this.userFavoriteService = userFavoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOption = null)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            List<Event> events;

            if (userId.HasValue)
            {
                events = await userFavoriteService.GetFavoriteEvents(userId.Value, sortOption);
            }
            else
            {
                events = null;
            }

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                await userFavoriteService.AddFavoriteEvent(id, userId.Value);
            }
            
            return RedirectToAction("Index", "UserFavorite");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                await userFavoriteService.DeleteFavoriteEvent(id, userId.Value);
            }

            return RedirectToAction("Index");
        }


    }
}


