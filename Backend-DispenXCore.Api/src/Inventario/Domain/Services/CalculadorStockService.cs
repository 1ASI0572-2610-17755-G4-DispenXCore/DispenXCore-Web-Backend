using Backend_DispenXCore.Api.src.Inventario.Domain.Entities;

namespace Backend_DispenXCore.Api.src.Inventario.Domain.Services;
public class CalculadorStockService
{
    public double CalcularPorcentajeRestante(Contenedor contenedor) => contenedor.PorcentajeRestante;
}