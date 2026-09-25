using PROYECTO_MONGO_DOTNET.Models;
namespace PROYECTO_MONGO_DOTNET.Services;
public sealed class PermisoDAO(SqlContexto db):SqlDAO(db)
{
 public bool TienePermiso(string p,string o,PermisoAccion a=PermisoAccion.Ver)=>true;
 public List<PermisoPerfil> ListarPorPerfil(string p)=>new();
 public void GuardarPerfil(string p,IEnumerable<PermisoPerfil> permisos,string u){}
}
