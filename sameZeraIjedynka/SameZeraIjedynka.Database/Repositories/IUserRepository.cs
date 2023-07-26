﻿using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string username, string password);
        Task<int> FindUserId(string username, string password);
        Task<User> GetUserById(int id);
        Task UpdateUser(User user, string newUsername, string newPassword);
    }
}