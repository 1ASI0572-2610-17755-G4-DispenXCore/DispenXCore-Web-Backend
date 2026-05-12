using Backend_DispenXCore.Api.Shared.Kernel;

namespace Backend_DispenXCore.Api.src.Notificaciones.Domain.Entities;
public class Alerta : BaseEntity
{
    public Guid ContenedorId { get; private set; }
    public string Grano { get; private set; }
    public double PorcentajeActual { get; private set; }
    public double UmbralDisparo { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public bool Enviada { get; private set; }

    // Constructor con parámetros que coinciden con las propiedades
    public Alerta(Guid contenedorId, string grano, double porcentajeActual, double umbralDisparo)
    {
        ContenedorId = contenedorId;
        Grano = grano;
        PorcentajeActual = porcentajeActual;
        UmbralDisparo = umbralDisparo;   // antes se llamaba 'umbral'
        FechaCreacion = DateTime.UtcNow;
        Enviada = false;
    }

    public void MarcarEnviada() => Enviada = true;
}