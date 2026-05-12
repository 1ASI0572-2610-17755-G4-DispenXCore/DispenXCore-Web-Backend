using Backend_DispenXCore.Api.src.IAM.Domain.Entities;

namespace Backend_DispenXCore.Api.src.IAM.Application.Interfaces;
public interface ITokenService
{
    string GenerateToken(User user);
}