using SameZeraIjedynka.Database.Entities;

namespace SameZeraIjedynka.Database.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User newUser);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(User user, int newId, string newUsername, string newPassword);
    }
}