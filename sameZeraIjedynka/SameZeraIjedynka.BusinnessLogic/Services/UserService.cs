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
            await userRepository.AddUser(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();

            return users;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await userRepository.GetUserById(id);
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

        public async Task UpdateUser(UserModel model, User newUser)
        {
            var user = await userRepository.GetUserById(model.Id);
            
            if (user != null)
            {
                await userRepository.UpdateUser(user, model.Id, model.Name, model.Password);
            }
        }

        /*public async Task DeleteUser(UserModel model)
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
