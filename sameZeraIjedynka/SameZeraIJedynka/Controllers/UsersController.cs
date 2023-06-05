using Microsoft.AspNetCore.Mvc;
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
    }
}
