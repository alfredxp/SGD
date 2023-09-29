using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SGDApi.Data;
using SGDApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SGDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        ApiDbContext _db = new ApiDbContext();
        private IConfiguration _config;

        public UsuariosController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] Usuarios usuarios)
        {
            var userExists = _db.Usuarios.FirstOrDefault(x => x.UsuarioLogin == usuarios.UsuarioLogin);
            if (userExists != null)
            {
                return BadRequest("El usuario ya existe");
            }
            _db.Usuarios.Add(usuarios);
            _db.SaveChanges();
            return new ObjectResult("El usuario ha sido creado correctamente") { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] Usuarios usuarios)
        {
            var currentUser = _db.Usuarios.FirstOrDefault(u => u.UsuarioLogin == usuarios.UsuarioLogin && u.UsuarioContrasena == usuarios.UsuarioContrasena);
            if (currentUser == null)
            {
                return NotFound("El usuario no existe");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, usuarios.UsuarioLogin),
            };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt);
        }


    }
}
