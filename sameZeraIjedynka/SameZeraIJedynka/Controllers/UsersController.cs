﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Context;
using SameZeraIJedynka.BusinnessLogic.Models;

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
        public async Task<IActionResult> Add(UserModel addUserRequest)
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
      
        public async Task<IActionResult> View(int id)
        {
            var user = await mvcDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
      
            if (user != null)
            {
                var viewModel = new UserModel()
                {
                    Id = user.UserId,
                    Name = user.Name,
                    Password = user.Password
                };
                return  await Task.Run(() => View("View",viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
   
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
        }
    }
}

