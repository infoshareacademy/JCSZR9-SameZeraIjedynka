using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IEventRepository
    {
        Task<int> AddEvent(Event newEvent);
        Task<IQueryable<Event>> Get();
        Task<IQueryable<Event>> Search(string searchPattern);
    }
}