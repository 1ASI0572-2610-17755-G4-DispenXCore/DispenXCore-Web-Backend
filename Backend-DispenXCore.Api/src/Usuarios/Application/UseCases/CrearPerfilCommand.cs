using Backend_DispenXCore.Api.src.Usuarios.Application.Interfaces;
using Backend_DispenXCore.Api.src.Usuarios.Domain.Entities;

namespace Backend_DispenXCore.Api.src.Usuarios.Application.UseCases;
public class CrearPerfilCommand
{
    private readonly IPerfilRepository _repo;
    public CrearPerfilCommand(IPerfilRepository repo) => _repo = repo;

    public async Task Execute(Guid userId, string nombreCompleto)
    {
        var perfil = new PerfilUsuario(userId, nombreCompleto);
        await _repo.AddAsync(perfil);
        await _repo.SaveChangesAsync();
    }
}