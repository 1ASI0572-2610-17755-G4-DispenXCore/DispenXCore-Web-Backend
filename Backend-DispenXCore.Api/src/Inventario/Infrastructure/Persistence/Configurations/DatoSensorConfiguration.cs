using Backend_DispenXCore.Api.src.Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_DispenXCore.Api.src.Inventario.Infrastructure.Persistence.Configurations;
public class DatoSensorConfiguration : IEntityTypeConfiguration<DatoSensor>
{
    public void Configure(EntityTypeBuilder<DatoSensor> builder)
    {
        builder.ToTable("datos_sensor");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.ContenedorId);
        builder.Property(d => d.Peso);
        builder.Property(d => d.Nivel);
        builder.Property(d => d.Flujo);
        builder.Property(d => d.Timestamp);
    }
}