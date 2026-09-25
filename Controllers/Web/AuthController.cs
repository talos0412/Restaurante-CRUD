using Microsoft.AspNetCore.Mvc;
using PROYECTO_MONGO_DOTNET.Services;

namespace PROYECTO_MONGO_DOTNET.Controllers;

public class AuthController : Controller
{
    private readonly UsuarioDAO _usuarios;
    public AuthController(UsuarioDAO usuarios) => _usuarios = usuarios;

    [HttpGet("/")]
    [HttpGet("/index.jsp")]
    public IActionResult Index(string? error, string? num)
    {
        ViewBag.Error = error;
        ViewBag.Num = num;
        return View();
    }

    [HttpPost("/Controller")]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string usuario, string password)
    {
        if (usuario == "admin" && password == "admin123")
        {
            HttpContext.Session.SetString("usuarioLogueado", "admin");
            HttpContext.Session.SetString("usuarioNombre", "Administrador (Mock)");
            HttpContext.Session.SetString("perfilCodigo", "ADMIN");
            HttpContext.Session.SetString("perfilNombre", "Administrador");
            HttpContext.Session.SetString("requiereCambioClave", "N");
            return Redirect("/pagPrincipal.jsp");
        }
        else if (usuario == "user" && password == "user123")
        {
            HttpContext.Session.SetString("usuarioLogueado", "user");
            HttpContext.Session.SetString("usuarioNombre", "Usuario Comun (Mock)");
            HttpContext.Session.SetString("perfilCodigo", "USER");
            HttpContext.Session.SetString("perfilNombre", "Estandar");
            HttpContext.Session.SetString("requiereCambioClave", "N");
            return Redirect("/pagPrincipal.jsp");
        }

        return Redirect("/index.jsp?error=usuario_no_existe");
    }

    [HttpGet("/Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        Response.Headers.CacheControl = "no-cache, no-store, must-revalidate";
        Response.Headers.Pragma = "no-cache";
        Response.Headers.Expires = "0";
        return Redirect("/index.jsp");
    }
}
