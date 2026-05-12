using Backend_DispenXCore.Api.src.Inventario.Application.Interfaces;
using Backend_DispenXCore.Api.src.Inventario.Domain.Entities;
using Backend_DispenXCore.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend_DispenXCore.Api.src.Inventario.Infrastructure.Persistence;
public class InventarioRepository : IInventarioRepository
{
    private readonly DispenXDbContext _context;
    public InventarioRepository(DispenXDbContext context) => _context = context;

    public async Task<Contenedor?> GetByIdAsync(Guid id) =>
        await _context.Contenedores.FindAsync(id);
    public async Task<List<Contenedor>> GetAllAsync() =>
        await _context.Contenedores.ToListAsync();
    public async Task AddAsync(Contenedor contenedor) =>
        await _context.Contenedores.AddAsync(contenedor);
    public async Task AddDatoSensorAsync(DatoSensor dato) =>
        await _context.DatosSensor.AddAsync(dato);
    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}