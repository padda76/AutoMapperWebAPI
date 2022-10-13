using AutoMapperWebAPI.Entities;

namespace AutoMapperWebAPI.Services;
public class UserService : IUserService
{
    private static readonly List<User> _users = new();
    public UserService()
    {
        _users.Add(new()
        {
            Id = 1,
            FirstName = "Tore",
            LastName = "Tang",
            Birthdate = new DateTime(1976, 4, 26)
        });
        _users.Add(new()
        {
            Id = 2,
            FirstName = "Kari",
            LastName = "Klo",
            Birthdate = new DateTime(1986, 4, 26)
        });
        _users.Add(new()
        {
            Id = 3,
            FirstName = "Arne",
            LastName = "Allsang",
            Birthdate = new DateTime(1966, 4, 26)
        });

    }

    public List<User> GetUsers()
    {
        return _users;
    }

    public User? GetUser(int id)
    {
        var user = _users.Where(u => u.Id == id).FirstOrDefault();
        if (user == null)
        {
            return null;
        }
        return user;
    }

    public User addUser(User user)
    {
        var id = _users.Max(u => u.Id);
        user.Id = id + 1;
        _users.Add(user);
        return user;
    }

    public void UpdateUser(int id, User user)
    {
        if(user != null && id > 0)
        {
            var dbUser = _users.Where(u => u.Id == id).FirstOrDefault();
            if(dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Birthdate = user.Birthdate;
            }
        }
    }

    public void DeleteUser(int id)
    {
        if(id > 0)
        {
            var userToDelete = GetUser(id);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
        }
    }
}
