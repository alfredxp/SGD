using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SGDApi.Models
{
    public class Usuarios
    {
        [Key]
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string? UsuarioLogin { get; set; }
        [Column(TypeName = "VARCHAR")]
        [Required]
        public string? UsuarioContrasena { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? UsuarioNombre { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? UsuarioApellido { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? UsuarioCorreo { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(12)]
        public string? UsuarioTelefono { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(13)]
        public string? UsuarioCedula { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public bool UsuarioTwoFactor { get; set; }
        public string? UsuarioLlaveQR { get; set; }
        public DateTime? FechaUltimaRevision { get; set; }
        public DateTime? FechaOrigen { get; set; } 

        [JsonIgnore]
        public virtual ICollection<LogActividades>? LogActividades { get; set; }

    }
}
