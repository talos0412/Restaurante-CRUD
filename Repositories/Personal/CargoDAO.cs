using PROYECTO_MONGO_DOTNET.Models;
namespace PROYECTO_MONGO_DOTNET.Services;
public sealed class CargoDAO(SqlContexto db,CodigoDAO codigo):SqlDAO(db)
{
 public List<Cargo> Listar() => MockData.Cargos.ToList();
 public List<Cargo> PorDepartamento(string d) => MockData.Cargos.Where(x => x.PedepCodigo == d).ToList();
 public Cargo? Buscar(string d,string c) => MockData.Cargos.FirstOrDefault(x => x.PedepCodigo == d && x.PecarCodigo == c);
 public bool Insertar(Cargo x){ x.PecarCodigo = "CAR" + DateTime.Now.Ticks; MockData.Cargos.Add(x); return true; }
 public bool Actualizar(Cargo x){ var e = Buscar(x.PedepCodigo, x.PecarCodigo); if(e!=null) e.PecarDescri = x.PecarDescri; return true; }
 public bool Eliminar(string d,string c){ var e = Buscar(d, c); if(e!=null) MockData.Cargos.Remove(e); return true; }
 public bool EnUso(string d,string c)=> false;
}
