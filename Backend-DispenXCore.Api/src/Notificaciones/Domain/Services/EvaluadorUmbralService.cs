namespace Backend_DispenXCore.Api.src.Notificaciones.Domain.Services;
public class EvaluadorUmbralService
{
    public bool DebeAlertar(double porcentajeActual, double umbral) =>
        porcentajeActual <= umbral;
}