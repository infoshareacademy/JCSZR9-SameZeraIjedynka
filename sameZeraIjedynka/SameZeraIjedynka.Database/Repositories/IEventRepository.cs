using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IEventRepository
    {
        Task<int> AddEvent(Event newEvent);
        Task Delete(Event eventsQuery);
        Task<IQueryable<Event>> Get();
        Task<Event> GetById(int eventId);
        Task<IQueryable<Event>> GetHomeEvents();
        Task<IQueryable<Event>> Search(string searchPattern);
    }
}