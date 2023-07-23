﻿using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Repositories
{
    public class UserFavoriteRepository : IUserFavoriteRepository
    {
        private readonly DatabaseContext context;
        public UserFavoriteRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<IQueryable<Event>> Get()
        {
            IQueryable<Event> eventsQuery = context.Favorites.Where(x => x.UserId == 2).Select(x => x.Event);

            return eventsQuery;
        }

        public async Task Add(UserFavorite newFavorite)
        {
            await context.Favorites.AddAsync(newFavorite);
            await context.SaveChangesAsync(); 
        }

        public async Task Delete(UserFavorite newFavorite)
        {
            context.Favorites.Remove(newFavorite); 
            await context.SaveChangesAsync();
        }

        public async Task<UserFavorite> Find(int id)
        {
            var eventsQuery = await context.Favorites.FirstOrDefaultAsync(x => x.UserId == 2 && x.EventId == id);

            return eventsQuery;
        }
    }
}
