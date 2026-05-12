using Backend_DispenXCore.Api.src.Notificaciones.Application.Interfaces;
using Backend_DispenXCore.Api.src.Notificaciones.Domain.Entities;
using Backend_DispenXCore.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend_DispenXCore.Api.src.Notificaciones.Infrastructure.Persistence;
public class NotificacionRepository : INotificacionRepository
{
    private readonly DispenXDbContext _context;
    public NotificacionRepository(DispenXDbContext context) => _context = context;

    public async Task<List<Alerta>> GetAlertasPendientesAsync(Guid contenedorId) =>
        await _context.Alertas.Where(a => a.ContenedorId == contenedorId).ToListAsync();
    public async Task AddAsync(Alerta alerta) =>
        await _context.Alertas.AddAsync(alerta);
    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}