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
        private readonly DatabaseContext mvcDbContext;
        private readonly IUserService userService;

        public UsersController(DatabaseContext mvcDbContext)  
        {
            this.mvcDbContext = mvcDbContext;
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
            var user = await userService.GetUserById(id);
      
            if (user != null)
            {
                return  await Task.Run(() => View("View", user));
            }
            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public async Task<IActionResult> View(UserModel model)
        {
           var user = await mvcDbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                user.UserId = model.Id;
                user.Name = model.Name;
                user.Password = model.Password;

                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("View");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UserModel model)
        {
            var user = await mvcDbContext.Users.FindAsync(model.Id);
            if(user!= null)
            {
                mvcDbContext.Users.Remove(user);
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }*/
    }
}

