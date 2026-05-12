namespace Backend_DispenXCore.Api.src.Notificaciones.Application.Interfaces;
public interface IPushService
{
    Task EnviarPushAsync(string mensaje, string deviceToken);
}