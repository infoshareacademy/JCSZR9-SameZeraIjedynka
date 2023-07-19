using SameZeraIJedynka.Models;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserService
    {
        Task Add(UserModel addUserRequest);
/*        Task DeleteUser(UserModel model);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task UpdateUser(UserModel model);*/
    }
}