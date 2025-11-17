using CrudRazorCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrudRazorCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly DualDBContext _context;

        public AccountController(DualDBContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string correo, string password)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Debes ingresar correo y contraseña.";
                return View();
            }

            var correoNorm = correo.Trim();
            var passNorm = password.Trim();

            // Ajusta los nombres de propiedades según tu modelo Usuario
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo.Trim() == correoNorm
                                  && u.Password.Trim() == passNorm);

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            // ✅ Aquí ya está autenticado -> solo redirigimos
            return RedirectToAction("Index", "Home");
            // Si quieres que vaya a otro controlador/página, cámbialo aquí
        }

        // Opcional: "Cerrar sesión" solo regresa al Login
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
