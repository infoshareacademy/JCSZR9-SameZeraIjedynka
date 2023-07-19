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
    }
}
