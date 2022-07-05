using Microsoft.AspNetCore.Identity;

namespace WebApiDocumentationExample.Models;

public class User : IdentityUser
{
    public UserRoles Role { get; set; }
}

public enum UserRoles
{
    ADMIN,
    USER
}

public class UserDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}