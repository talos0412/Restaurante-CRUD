using PROYECTO_MONGO_DOTNET.Models.Entidades;
using PROYECTO_MONGO_DOTNET.Services;

namespace PROYECTO_MONGO_DOTNET.Repositories;

public interface IProyectoRepositorio
{
    Task<IReadOnlyCollection<Proyecto>> ListarAsync(bool incluirInactivos = false);
    Task<Proyecto?> ObtenerAsync(string codigo);
    Task<bool> ExisteCodigoAsync(string codigo);
    Task CrearAsync(Proyecto proyecto);
    Task<bool> ActualizarAsync(Proyecto proyecto);
}

public sealed class ProyectoRepositorio(SqlContexto db) : IProyectoRepositorio
{
    public Task<IReadOnlyCollection<Proyecto>> ListarAsync(bool incluirInactivos = false) => Task.FromResult((IReadOnlyCollection<Proyecto>)MockData.Proyectos.ToList());
    public Task<Proyecto?> ObtenerAsync(string codigo) => Task.FromResult(MockData.Proyectos.FirstOrDefault(x => x.Codigo == codigo));
    public Task<bool> ExisteCodigoAsync(string codigo) => Task.FromResult(MockData.Proyectos.Any(x => x.Codigo == codigo));
    public Task CrearAsync(Proyecto x) { MockData.Proyectos.Add(x); return Task.CompletedTask; }
    public Task<bool> ActualizarAsync(Proyecto x) { var p = MockData.Proyectos.FirstOrDefault(y => y.Codigo == x.Codigo); if(p != null) { p.Nombre = x.Nombre; return Task.FromResult(true); } return Task.FromResult(false); }
    private static string N(string? x) => (x ?? "").Trim().ToUpperInvariant();
}
