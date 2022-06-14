using Microsoft.AspNetCore.Mvc;
using CRUDCLIENTES.BDCliente;
using CRUDCLIENTES.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;



namespace CRUDCLIENTES.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioDatos _uDatos = new UsuarioDatos();
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuarioModel)
        {
            bool resultado = _uDatos.RegistrarUsuario(usuarioModel);
            string mensaje = _uDatos.devuelveMensaje();

            ViewData["Mensaje"] = mensaje;
            if (resultado)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioModel usuarioModel)
        {
            int resultado = _uDatos.LoginUsuario(usuarioModel);
            if (resultado != 0)
            {
                var claims = new List<Claim>{
                    new Claim("Correo", usuarioModel.Correo),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Listar", "Cliente");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no Registrado";
                return View();
            }
        }


        public async Task<IActionResult> Salir()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");

        }
    }
}
