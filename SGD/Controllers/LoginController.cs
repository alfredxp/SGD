using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGD.Helpers;
using SGD.Models;
using System.Security.Claims;

namespace SGD.Controllers
{
    public class LoginController : Controller
    {
        private readonly SGDContext _context;
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var user = await _context.usuarios.Where(x => x.USR_CORREO.Equals(username)).FirstOrDefaultAsync();
            HashPassword hashPassword = new HashPassword(password.Trim());

            {
                return Json(new { success = false, message = "El usuario o contraseña no coinciden" });
            }

            if (user.EST_ID == 2)
            {
                return Json(new { success = false, message = "El usuario ha sido desactivado" });
            }

            var claims = new List<Claim>
            {
                new Claim("Username", username),
                new Claim(ClaimTypes.NameIdentifier, user.USR_ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            //_logger.LogInformation($"El usuario ID {user.Id} {user.NombreCompleto} inicio sesión - IP {ipAddress}");

            return Json(new { success = true });
        }
        
    }
}
