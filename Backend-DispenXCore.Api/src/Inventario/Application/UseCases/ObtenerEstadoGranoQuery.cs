using Backend_DispenXCore.Api.src.Inventario.Application.Interfaces;

namespace Backend_DispenXCore.Api.src.Inventario.Application.UseCases;
public class ObtenerEstadoGranoQuery
{
    private readonly IInventarioRepository _repo;
    public ObtenerEstadoGranoQuery(IInventarioRepository repo) => _repo = repo;

    public async Task<List<object>> Execute()
    {
        var contenedores = await _repo.GetAllAsync();
        return contenedores.Select(c => new
        {
            c.Id,
            Grano = c.Grano.Nombre,
            PorcentajeRestante = c.PorcentajeRestante,
            PesoActual = c.PesoActual,
            NivelActual = c.NivelActual
        }).ToList<object>();
    }
}