using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.BusinnessLogic.Models;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using SameZeraIjedynka.Database.Repositories;
using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> GetUserModelById(int id)
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
        public async Task<int> GetUserId(UserModel model)
        {
            var userId = await userRepository.FindUserId(model.Name, model.Password);

            if (userId != null)
            {
                return userId;
            }
            return -1;
        }

        public async Task UpdateUser(UserModel user, UserModel model)
        {
            var userToUpdate = await userRepository.GetUserById(user.Id);

            if (userToUpdate != null)
            {
                await userRepository.UpdateUser(userToUpdate, model.Name, model.Password);
            }
        }

        public async Task<bool> AuthenticateUser(UserModel user)
        {
            var authenticatedUser = await userRepository.Authenticate(user.Name, user.Password);

            return authenticatedUser;
        }

        public async Task AddUser(RegisterUserModel addUserRequest)
        {
            if (addUserRequest.Password == addUserRequest.ConfirmPassword)
            {
                var user = new User()
                {
                    Name = addUserRequest.Name,
                    Password = addUserRequest.Password
                };
                await userRepository.AddUser(user);
            }
        }
    }
}
