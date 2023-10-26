
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SGDApp.Models
{
    public class Usuarios
    {
        
        public int UsuarioId { get; set; }
        
        public string? UsuarioLogin { get; set; }
        
        public string? UsuarioContrasena { get; set; }
        
        public string? UsuarioNombre { get; set; }
        
        public string? UsuarioApellido { get; set; }
        
        public string? UsuarioCorreo { get; set; }
        
        public string? UsuarioTelefono { get; set; }
        
        public string? UsuarioCedula { get; set; }
        
        public bool UsuarioTwoFactor { get; set; }
        public string? UsuarioLlaveQR { get; set; }
        public DateTime? FechaUltimaRevision { get; set; }
        public DateTime? FechaOrigen { get; set; } 

        [JsonIgnore]
        public virtual ICollection<LogActividades>? LogActividades { get; set; }

    }
}
