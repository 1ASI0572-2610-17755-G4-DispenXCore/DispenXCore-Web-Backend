using Backend_DispenXCore.Api.src.IAM.Application.Interfaces;
using Backend_DispenXCore.Api.src.IAM.Application.UseCases;
using Backend_DispenXCore.Api.src.IAM.Domain.Services;
using Backend_DispenXCore.Api.src.IAM.Infrastructure.Persistence;
using Backend_DispenXCore.Api.src.IAM.Infrastructure.Security;
using Backend_DispenXCore.Api.src.Inventario.Application.Interfaces;
using Backend_DispenXCore.Api.src.Inventario.Application.UseCases;
using Backend_DispenXCore.Api.src.Inventario.Domain.Services;
using Backend_DispenXCore.Api.src.Inventario.Infrastructure.Persistence;
using Backend_DispenXCore.Api.src.Notificaciones.Application.Interfaces;
using Backend_DispenXCore.Api.src.Notificaciones.Application.UseCases;
using Backend_DispenXCore.Api.src.Notificaciones.Domain.Services;
using Backend_DispenXCore.Api.src.Notificaciones.Infrastructure.Persistence;
using Backend_DispenXCore.Api.src.Notificaciones.Infrastructure.Services;
using Backend_DispenXCore.Api.src.Usuarios.Application.Interfaces;
using Backend_DispenXCore.Api.src.Usuarios.Application.UseCases;
using Backend_DispenXCore.Api.src.Usuarios.Infrastructure.Persistence;
using Backend_DispenXCore.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend_DispenXCore.Api.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DispenXDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Repositorios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPerfilRepository, PerfilRepository>();
        services.AddScoped<IInventarioRepository, InventarioRepository>();
        services.AddScoped<INotificacionRepository, NotificacionRepository>();

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<PasswordHasherService>();
        services.AddScoped<CalculadorStockService>();
        services.AddScoped<EvaluadorUmbralService>();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Auth & Token
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<LoginCommand>();
        services.AddScoped<RegisterCommand>();

        // Perfil Usuario
        services.AddScoped<CrearPerfilCommand>();
        services.AddScoped<VincularDispensadorCommand>();

        // Inventario
        services.AddScoped<RegistrarMedicionCommand>();
        services.AddScoped<ObtenerEstadoGranoQuery>();

        // Notificaciones
        services.AddScoped<EvaluarAlertasCommand>();
        services.AddScoped<ObtenerAlertasQuery>();
        services.AddScoped<IPushService, PushNotificationService>();

        return services;
    }
}