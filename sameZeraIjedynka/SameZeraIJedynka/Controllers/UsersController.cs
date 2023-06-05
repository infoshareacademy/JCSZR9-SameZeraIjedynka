using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIJedynka.Models;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;


namespace SameZeraIJedynka.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext mvcDbContext;  // assign field to what is below

        public UsersController(DatabaseContext mvcDbContext)  //constructor //in bracket injected service. Pres dot+CTRL to create an asign field
        {
            this.mvcDbContext = mvcDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserModel addUserRequest)
        {
            var user = new User() //conversion between models
            {
                UserId = addUserRequest.Id,
                Name = addUserRequest.Name,
                Password = addUserRequest.Password
            };
            await mvcDbContext.Users.AddAsync(user); //adding to list next employee
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await mvcDbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var user = mvcDbContext.Users.FirstOrDefault(x => x.UserId == id);
      
            if (user != null)
            {
                var viewModel = new UpdateUserViewModel()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Password = user.Password
                };
                return  View(viewModel);
            }
            return RedirectToAction("Index");
        }




    }
}
