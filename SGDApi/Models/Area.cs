using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApi.Models
{
    public class Area
    {
        [Key]
        [Column("AreaId")]
        public int AreaId { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaUltimaRevision { get; set; }
        public DateTime? FechaOrigen { get; set; }

        [ForeignKey(nameof(UsuariosModificacion))]
        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }
        [ForeignKey(nameof(UsuariosCreador))]
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }
    }
}
