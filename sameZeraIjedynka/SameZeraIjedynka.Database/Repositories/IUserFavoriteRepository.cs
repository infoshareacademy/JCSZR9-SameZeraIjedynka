using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IUserFavoriteRepository
    {
        Task<IQueryable<Event>> Get();
    }
}