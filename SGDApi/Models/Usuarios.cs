using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApi.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string UsuarioLogin { get; set; }
        [Column(TypeName = "VARCHAR")]
        [Required]
        public string Contrasena { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string UsuarioNombre { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string UsuarioApellido { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string UsuarioCorreo { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(12)]
        public string UsuarioTelefono { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(13)]
        public string UsuarioCedula { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public bool UsuarioTwoFactor { get; set; }
        public string UsuarioLlaveQR { get; set; }
        public DateTime? UsuarioFechaCreacion { get; set; }
        public DateTime? UsuarioFechaModificacion { get; set; } 
        public int EstadoId { get; set; }

        public virtual Estados Estados { get; set; }

    }
}
