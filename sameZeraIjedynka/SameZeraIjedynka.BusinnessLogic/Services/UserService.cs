using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Repositories;
using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(DatabaseContext dbContext, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Add(UserModel addUserRequest)
        {
            var user = new User()
            {
                UserId = addUserRequest.Id,
                Name = addUserRequest.Name,
                Password = addUserRequest.Password
            };
            await userRepository.Add(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();

            return users;
        }

        /*public async Task<UserModel> GetUserById(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user != null)
            {
                var userModel = new UserModel
                {
                    Id = user.UserId,
                    Name = user.Name,
                    Password = user.Password
                };
                return userModel;
            }
            return null;
        }

        public async Task UpdateUser(UserModel model)
        {
            var user = await dbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                user.UserId = model.Id;
                user.Name = model.Name;
                user.Password = model.Password;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(UserModel model)
        {
            var user = await dbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }*/
    }
}
