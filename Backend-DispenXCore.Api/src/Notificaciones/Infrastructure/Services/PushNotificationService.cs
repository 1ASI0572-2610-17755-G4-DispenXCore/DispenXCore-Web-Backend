using Backend_DispenXCore.Api.src.Notificaciones.Application.Interfaces;

namespace Backend_DispenXCore.Api.src.Notificaciones.Infrastructure.Services;
public class PushNotificationService : IPushService
{
    public Task EnviarPushAsync(string mensaje, string deviceToken)
    {
        // Aquí conectarías con Firebase Cloud Messaging, OneSignal, etc.
        Console.WriteLine($"Push enviado a {deviceToken}: {mensaje}");
        return Task.CompletedTask;
    }
}