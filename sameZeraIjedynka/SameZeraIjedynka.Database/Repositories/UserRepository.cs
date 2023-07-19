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

        public async Task Add(User newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
        }
    }
}
