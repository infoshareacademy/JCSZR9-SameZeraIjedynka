using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;

using SameZeraIjedynka.BusinnessLogic.Services;
using SameZeraIJedynka.Models;
using SameZeraIjedynka.BusinnessLogic.Models;

namespace SameZeraIJedynka.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)  
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                var user = await userService.GetUserModelById(userId.Value);

                if (user != null)
                {
                    return View(user);
                }
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel model)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                var user = await userService.GetUserModelById(userId.Value);

                if (user != null)
                {
                    await userService.UpdateUser(user, model);
                    // TODO: Show User That Data Has Been Updated
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel user)
        {
            if (ModelState.IsValid)
            {
                if (await userService.IsUsernameUnique(user.Name))
                {
                    await userService.AddUser(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Name", "Użytkownik o podanej nazwie już istnieje.");
                }
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = await userService.AuthenticateUser(model);

                if (isAuthenticated)
                {
                    var userId = await userService.GetUserId(model);
                    HttpContext.Session.SetInt32("UserId", userId);
                    
                    return RedirectToAction("Index", new { id = userId });
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło.");
                }
            }

            return View(model);
        }
    }
}

