using Backend_DispenXCore.Api.src.Inventario.Domain.ValueObjects;
using Backend_DispenXCore.Api.Shared.Kernel;

namespace Backend_DispenXCore.Api.src.Inventario.Domain.Entities;

public class Contenedor : BaseEntity
{
    // Propiedades con setters privados (EF Core puede escribirlas por reflexión)
    public TipoGrano Grano { get; private set; }
    public Capacidad CapacidadMaxima { get; private set; }
    public double PesoActual { get; private set; }
    public double NivelActual { get; private set; }

    // Calculado, sin setter
    public double PorcentajeRestante => (PesoActual / CapacidadMaxima.Valor) * 100;

    // Constructor sin parámetros requerido por EF Core
    private Contenedor() { Id = Guid.NewGuid(); }

    // Fábrica para crear instancias de forma controlada
    public static Contenedor Crear(TipoGrano grano, Capacidad capacidadMaxima)
    {
        return new Contenedor
        {
            Grano = grano,
            CapacidadMaxima = capacidadMaxima
        };
    }

    public void ActualizarMedicion(double peso, double nivel)
    {
        PesoActual = peso;
        NivelActual = nivel;
    }
}