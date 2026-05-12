using Backend_DispenXCore.Api.src.Inventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_DispenXCore.Api.src.Inventario.Infrastructure.Persistence.Configurations;
public class ContenedorConfiguration : IEntityTypeConfiguration<Contenedor>
{
    public void Configure(EntityTypeBuilder<Contenedor> builder)
    {
        builder.ToTable("contenedores");
        builder.HasKey(c => c.Id);
        builder.OwnsOne(c => c.Grano, g =>
        {
            g.Property(p => p.Nombre).HasColumnName("Grano").HasMaxLength(100);
        });
        builder.OwnsOne(c => c.CapacidadMaxima, cap =>
        {
            cap.Property(p => p.Valor).HasColumnName("CapacidadMaxima_Valor");
            cap.Property(p => p.Unidad).HasColumnName("CapacidadMaxima_Unidad").HasMaxLength(10);
        });
        builder.Property(c => c.PesoActual);
        builder.Property(c => c.NivelActual);
    }
}