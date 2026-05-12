using Backend_DispenXCore.Api.src.Notificaciones.Domain.Entities;

namespace Backend_DispenXCore.Api.src.Notificaciones.Application.Interfaces;
public interface INotificacionRepository
{
    Task<List<Alerta>> GetAlertasPendientesAsync(Guid contenedorId);
    Task AddAsync(Alerta alerta);
    Task SaveChangesAsync();
}