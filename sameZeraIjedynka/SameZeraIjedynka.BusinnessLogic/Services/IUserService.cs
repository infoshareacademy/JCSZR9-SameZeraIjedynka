using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserService
    {
        Task Add(UserModel addUserRequest);
        Task DeleteUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<UserModel> GetUserModelById(int id);
        Task UpdateUser(User user, UserModel model);
    }
}