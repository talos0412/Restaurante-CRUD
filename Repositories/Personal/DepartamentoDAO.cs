using PROYECTO_MONGO_DOTNET.Models;
namespace PROYECTO_MONGO_DOTNET.Services;
public sealed class DepartamentoDAO(SqlContexto db,CodigoDAO codigo):SqlDAO(db)
{
 public List<Departamento> Listar() => MockData.Departamentos.ToList();
 public Departamento? Buscar(string c)=> MockData.Departamentos.FirstOrDefault(d => d.Codigo == c);
 public bool Insertar(Departamento x){ x.Codigo = "DEP" + DateTime.Now.Ticks; MockData.Departamentos.Add(x); return true;}
 public bool Actualizar(Departamento x){ var e = Buscar(x.Codigo); if(e!=null) e.Descripcion = x.Descripcion; return true; }
 public bool Eliminar(string c){ var e = Buscar(c); if(e!=null) MockData.Departamentos.Remove(e); return true; }
 public bool EnUso(string c)=> false;
}
