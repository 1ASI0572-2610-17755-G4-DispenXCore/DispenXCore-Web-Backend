using Backend_DispenXCore.Api.Shared.Kernel;

namespace Backend_DispenXCore.Api.src.Inventario.Domain.Entities;
public class DatoSensor : BaseEntity
{
    public Guid ContenedorId { get; private set; }
    public double Peso { get; private set; }
    public double Nivel { get; private set; }
    public double Flujo { get; private set; }
    public DateTime Timestamp { get; private set; }

    public DatoSensor(Guid contenedorId, double peso, double nivel, double flujo)
    {
        ContenedorId = contenedorId;
        Peso = peso;
        Nivel = nivel;
        Flujo = flujo;
        Timestamp = DateTime.UtcNow;
    }
}