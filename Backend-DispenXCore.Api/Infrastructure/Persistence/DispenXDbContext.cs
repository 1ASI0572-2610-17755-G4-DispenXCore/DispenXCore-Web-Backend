using Backend_DispenXCore.Api.src.IAM.Domain.Entities;
using Backend_DispenXCore.Api.src.Inventario.Domain.Entities;
using Backend_DispenXCore.Api.src.Notificaciones.Domain.Entities;
using Backend_DispenXCore.Api.src.Usuarios.Domain.Entities;
using Backend_DispenXCore.Api.Shared.Kernel;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backend_DispenXCore.Api.Infrastructure.Persistence;

public class DispenXDbContext : DbContext, IUnitOfWork
{
    public DispenXDbContext(DbContextOptions<DispenXDbContext> options) : base(options) { }

    // IAM
    public DbSet<User> IamUsers => Set<User>();
    // Usuarios
    public DbSet<PerfilUsuario> PerfilesUsuarios => Set<PerfilUsuario>();
    public DbSet<Dispensador> Dispensadores => Set<Dispensador>();
    // Inventario
    public DbSet<Contenedor> Contenedores => Set<Contenedor>();
    public DbSet<DatoSensor> DatosSensor => Set<DatoSensor>();
    // Notificaciones
    public DbSet<Alerta> Alertas => Set<Alerta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}