using Backend_DispenXCore.Api.Shared.Kernel;

namespace Backend_DispenXCore.Api.src.IAM.Domain.Entities;
public class User : BaseEntity
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
}