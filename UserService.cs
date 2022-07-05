using WebApiDocumentationExample.Models;

namespace WebApiDocumentationExample.Controllers;

public interface IUserService
{
    (bool, User) ValidateUser(string username, string password);
}

public class UserService : IUserService
{
    private static readonly List<User> _users = new List<User>
    {
        new User { Id = "1", UserName = "admin", PasswordHash = "admin", Role = UserRoles.ADMIN },
        new User { Id = "2", UserName = "regularUser", PasswordHash = "regularUser", Role = UserRoles.USER }
    };
    
    public (bool, User) ValidateUser(string username, string password)
    {
        var user = _users.FirstOrDefault(x => x.UserName == username && x.PasswordHash == password);
        return user == null ? (false, null) : (true, user);
    }
}