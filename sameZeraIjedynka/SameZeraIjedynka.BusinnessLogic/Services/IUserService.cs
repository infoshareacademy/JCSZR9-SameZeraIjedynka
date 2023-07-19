using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserService
    {
        Task Add(UserModel addUserRequest);
        Task<List<User>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task UpdateUser(UserModel model, User user);
    }
}