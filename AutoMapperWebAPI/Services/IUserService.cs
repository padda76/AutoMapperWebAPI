using AutoMapperWebAPI.Entities;

namespace AutoMapperWebAPI.Services
{
    public interface IUserService
    {
        User addUser(User user);
        User? GetUser(int id);
        List<User> GetUsers();
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}