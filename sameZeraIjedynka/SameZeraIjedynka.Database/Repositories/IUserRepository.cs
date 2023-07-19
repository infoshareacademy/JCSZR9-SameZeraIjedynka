using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IUserRepository
    {
        Task Add(User newUser);
    }
}