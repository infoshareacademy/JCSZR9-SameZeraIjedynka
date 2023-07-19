using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public readonly DatabaseContext context;
        public UserRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task AddUser(User newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            return user;
        }

        public async Task UpdateUser(User user, int newId, string newUsername, string newPassword)
        {
            user.UserId = newId;
            user.Name = newUsername;
            user.Password = newPassword;
            await context.SaveChangesAsync();
        }
    }
}
