using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGD.Helpers;
using SGD.Models;
using SGD.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace SGD.Controllers
{
    public class HomeController : Controller
    {
        private readonly SGDContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<LoginController> _logger;
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SolicitarIngreso()
        {
            return View();
        }

        public HomeController(SGDContext context, ILogger<LoginController> logger, IHttpContextAccessor contextAccessor)
        {

            _context = context;
            _logger = logger;
            _contextAccessor = contextAccessor;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var user = await _context.usuarios.Where(x => x.USR_CORREO.Equals(username)).FirstOrDefaultAsync();
            HashPassword hashPassword = new HashPassword(password.Trim());

            if (user is null || !hashPassword.PasswordVerify(user.USR_CONTRASENA))
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

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }


        public IActionResult ValidatedPassword(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidatedPassword([Bind("Password, PasswordConfirm")] UsuarioValidatedPassword usuarioPaswword)
        {

            if (ModelState.IsValid)
            {


                if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var identity = (ClaimsIdentity)_contextAccessor.HttpContext.User.Identity;
                    var IsActivado = identity.Claims.FirstOrDefault(p => p.Type == "IsActivado");

                    if (IsActivado != null)
                    {
                        identity.RemoveClaim(IsActivado);
                    }

                    identity.AddClaim(new Claim("IsActivado", "true"));

                    var userId = identity.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
                    var userFromDb = Int32.TryParse(userId, out int Id) ? await _context.usuarios.FindAsync(Id) : null;

                    if (userFromDb is null)
                    {
                        return RedirectToAction("Login");
                    }

                    HashPassword password = new HashPassword(usuarioPaswword.Password);
                    userFromDb.USR_CONTRASENA = password.Hash();

                    await _context.SaveChangesAsync();


                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = true,
                    });

                    return RedirectToAction("Index", "App_Users");

                }

                return NotFound($"El usuario no esta correctamente autenticado.");

            }

            return View(usuarioPaswword);

        }
    }
}