using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SameZeraIJedynka.BusinnessLogic.Models;
using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public class UserFavoriteService
    {
        private readonly DatabaseContext mvcDbContext;

        public UserFavoriteService(DatabaseContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        public async Task<List<Event>> GetFavoriteEvents(int userId, string sortOption = null)
        {
            var eventsQuery = mvcDbContext.Favorites.Where(x => x.UserId == userId).Select(x => x.Event);

            switch (sortOption)
            {
                case "time_left":
                    eventsQuery = eventsQuery.OrderBy(e => e.Date);
                    break;
                case "time_left_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Date);
                    break;
                case "price":
                    eventsQuery = eventsQuery.OrderBy(e => e.Price);
                    break;
                case "price_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Price);
                    break;
                default:
                    eventsQuery = eventsQuery;
                    break;
            }

            var events = await eventsQuery.ToListAsync();

            return events;
        }

        public async Task AddFavoriteEvent(int userId, int eventId)
        {
            var newFavorite = new UserFavorite()
            {
                EventId = eventId,
                UserId = userId
            };
            await mvcDbContext.Favorites.AddAsync(newFavorite);
            await mvcDbContext.SaveChangesAsync();
        }

        public async Task DeleteFavoriteEvent(int userId, int eventId)
        {
            var favorite = await mvcDbContext.Favorites.FirstOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId);
            if (favorite != null)
            {
                mvcDbContext.Favorites.Remove(favorite);
                await mvcDbContext.SaveChangesAsync();
            }
        }
    }
}
