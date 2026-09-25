using PROYECTO_MONGO_DOTNET.Models;
using PROYECTO_MONGO_DOTNET.Models.Entidades;

namespace PROYECTO_MONGO_DOTNET;

public static class MockData {
    public static List<Departamento> Departamentos = new() {
        new() { Codigo = "DEP01", Descripcion = "Recursos Humanos" },
        new() { Codigo = "DEP02", Descripcion = "Tecnología" }
    };
    public static List<Cargo> Cargos = new() {
        new() { PedepCodigo = "DEP01", PecarCodigo = "CAR01", PecarDescri = "Gerente RRHH", NombreDepartamento = "Recursos Humanos", EsJefeProyecto = true },
        new() { PedepCodigo = "DEP02", PecarCodigo = "CAR02", PecarDescri = "Desarrollador Senior", NombreDepartamento = "Tecnología", EsJefeProyecto = false }
    };
    public static List<Empleado> Empleados = new() {
        new() { PeempCodigo = "EMP01", PedepCodigo = "DEP02", PecarCodigo = "CAR02", PedPedepCodigo = "DEP02", NombreDepartamento = "Tecnología", NombreCargo = "Desarrollador Senior", Persona = new Persona { PeperCodigo = "PER01", Nombres = "Juan", Apellidos = "Pérez", Email = "juan@test.com", Foto = "https://i.pravatar.cc/150?img=11" } }
    };
    public static List<Proyecto> Proyectos = new() {
        new() { Codigo = "PRY01", Nombre = "Migración Cloud", Descripcion = "Migración a AWS", Estado = "PLANIFICADO" }
    };
}
