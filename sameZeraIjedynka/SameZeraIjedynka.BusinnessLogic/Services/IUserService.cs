﻿using SameZeraIjedynka.BusinnessLogic.Models;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserModelById(int id);
        Task<bool> AuthenticateUser(UserModel user);
        Task<int> GetUserId(UserModel model);
        Task UpdateUser(UserModel user, UserModel model);
        Task AddUser(RegisterUserModel addUserRequest);
        Task<bool> IsUsernameUnique(string username);
    }
}