using Backend_DispenXCore.Api.src.Usuarios.Domain.Entities;

namespace Backend_DispenXCore.Api.src.Usuarios.Application.Interfaces;
public interface IPerfilRepository
{
    Task<PerfilUsuario?> GetByUserIdAsync(Guid userId);
    Task AddAsync(PerfilUsuario perfil);
    Task<Dispensador?> GetDispensadorByCodigoAsync(string codigo);
    Task AddDispensadorAsync(Dispensador dispensador);
    Task SaveChangesAsync();
}