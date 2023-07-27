using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.BusinnessLogic.Helpers.HelperMethods;
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
        public async Task<int> GetUserId(LoginUserModel model)
        {
            var hashedPassword = HelperMethods.HashPassword(model.Password);
            var userId = await userRepository.FindUserId(model.Name, hashedPassword);

            if (userId != null)
            {
                return userId;
            }
            return -1;
        }
        public async Task<bool> IsUsernameUnique(string username)
        {
            var existingUser = await userRepository.GetUserByName(username);

            return existingUser == null;
        }

        public async Task UpdateUser(UserModel user, UserModel model)
        {
            var userToUpdate = await userRepository.GetUserById(user.Id);

            if (userToUpdate != null)
            {
                var hashedPassword = HelperMethods.HashPassword(model.Password);
                await userRepository.UpdateUser(userToUpdate, model.Name, hashedPassword);
            }
        }

        public async Task<bool> AuthenticateUser(LoginUserModel user)
        {
            var hashedPassword = HelperMethods.HashPassword(user.Password);
            var authenticatedUser = await userRepository.Authenticate(user.Name, hashedPassword);

            return authenticatedUser;
        }

        public async Task AddUser(RegisterUserModel addUserRequest)
        {
            if (addUserRequest.Password == addUserRequest.ConfirmPassword)
            {
                var hashedPassword = HelperMethods.HashPassword(addUserRequest.Password); 

                var user = new User()
                {
                    Name = addUserRequest.Name,
                    Password = hashedPassword,
                    Email = addUserRequest.Email,
                };
                await userRepository.AddUser(user);
            }
        }


    }
}
