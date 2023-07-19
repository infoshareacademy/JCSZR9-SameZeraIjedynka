using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IUserFavoriteRepository
    {
        Task Add(UserFavorite newFavorite);
        Task<IQueryable<Event>> Get();
    }
}