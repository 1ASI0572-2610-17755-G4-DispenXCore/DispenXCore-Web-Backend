using Backend_DispenXCore.Api.src.Usuarios.Application.Interfaces;
using Backend_DispenXCore.Api.src.Usuarios.Domain.Entities;
using Backend_DispenXCore.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend_DispenXCore.Api.src.Usuarios.Infrastructure.Persistence;
public class PerfilRepository : IPerfilRepository
{
    private readonly DispenXDbContext _context;
    public PerfilRepository(DispenXDbContext context) => _context = context;

    public async Task<PerfilUsuario?> GetByUserIdAsync(Guid userId) =>
        await _context.Set<PerfilUsuario>().FirstOrDefaultAsync(p => p.UserId == userId);

    public async Task AddAsync(PerfilUsuario perfil) =>
        await _context.Set<PerfilUsuario>().AddAsync(perfil);

    public async Task<Dispensador?> GetDispensadorByCodigoAsync(string codigo) =>
        await _context.Set<Dispensador>().FirstOrDefaultAsync(d => d.Codigo == codigo);

    public async Task AddDispensadorAsync(Dispensador dispensador) =>
        await _context.Set<Dispensador>().AddAsync(dispensador);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}