using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.Controllers;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;

namespace SameZeraIJedynka.Controllers
{
    public class UserFavoriteController : Controller
    {
        public UserFavoriteController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}


