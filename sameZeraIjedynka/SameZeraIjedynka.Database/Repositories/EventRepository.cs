using SameZeraIjedynka.Database.Context;
using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext context;
        public EventRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<int> AddEvent(Event newEvent)
        {
            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();

            return newEvent.EventId;
        }
    }
}
