using PROYECTO_MONGO_DOTNET.Models;
namespace PROYECTO_MONGO_DOTNET.Services;
public sealed class EmpleadoDAO(SqlContexto db,CodigoDAO codigo,PersonaDAO personas,DepartamentoDAO departamentos,CargoDAO cargos,FamiliarDAO familiares,FormacionDAO formaciones):SqlDAO(db)
{
 public List<Empleado> Listar()=>MockData.Empleados.ToList();
 public List<Empleado> ListarActivos()=>MockData.Empleados.ToList();
 public List<Empleado> ListarAsignablesProyecto()=>MockData.Empleados.ToList();
 public List<Empleado> ListarJefesProyecto()=>MockData.Empleados.ToList();
 public List<Empleado> Buscar(string criterio,string termino)=>MockData.Empleados.ToList();
 public Empleado? BuscarPorCodigo(string c)=>MockData.Empleados.FirstOrDefault(x=>x.PeempCodigo==Mayuscula(c));
 public Empleado? BuscarActivoPorCodigo(string c)=>BuscarPorCodigo(c);
 public bool TieneUsuarioActivo(string c)=>true;
 public bool EsJefeProyectoActivo(string c)=>false;
 public bool ExisteEmpleado(string c)=>BuscarPorCodigo(c)!=null;
 public bool ExisteEmpleadoPorPersona(string p)=>false;
 public bool ExisteEmpleadoConCedula(string c)=>false;
 public bool ExistePersona(string p)=>false; public bool ExisteCedula(string c)=>false; public bool ExisteCedulaEnOtraPersona(string c,string p)=>false;
 public void Guardar(Empleado e){ e.PeempCodigo = "EMP" + DateTime.Now.Ticks; MockData.Empleados.Add(e); }
 public void Actualizar(Empleado e){ var em = BuscarPorCodigo(e.PeempCodigo); if(em!=null){ em.Persona = e.Persona; } }
 public bool Eliminar(string c){ var em = BuscarPorCodigo(c); if(em!=null) MockData.Empleados.Remove(em); return true; }
 public bool EmpleadoTieneRelaciones(string e)=>false;
 public bool PersonaTieneRelacionesExternas(string p,string e)=>false;
 public bool CargoPerteneceDepartamento(string d,string c)=>true; public List<Departamento> ListarDepartamentos()=>departamentos.Listar(); public List<Cargo> ListarCargos()=>cargos.Listar(); public List<Cargo> CargosPorDepartamento(string d)=>cargos.PorDepartamento(d); public List<Catalogo> ListarSexos()=>new(); public List<Catalogo> ListarEstadosCiviles()=>new(); public List<Parentesco> ListarParentescos()=>new();
}
