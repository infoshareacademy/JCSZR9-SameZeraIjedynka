using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;
using SameZeraIJedynka.Models;
using SameZeraIjedynka.BusinnessLogic.Services;

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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserModel addUserRequest)
        {
            await userService.Add(addUserRequest);

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var user = await userService.GetUserModelById(id);
      
            if (user != null)
            {
                return  await Task.Run(() => View("View", user));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UserModel model)
        {
            var user = await userService.GetUserById(model.Id);

            if (user != null)
            {
                await userService.UpdateUser(user, model);
                return RedirectToAction("View");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserModel model)
        {
            var user = await userService.GetUserById(model.Id);

            if (user != null)
            {
                await userService.DeleteUser(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

