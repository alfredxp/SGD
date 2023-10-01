using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApi.Models
{
    public class Comentario
    {
        [Key]
        [Column("ComentarioId")]
        public int ComentarioId { get; set; }
        public string? Contenido { get; set; }
        [ForeignKey(nameof(TaskId))]
        public int? TaskId { get; set; }
        public virtual Task? Task { get; set; }
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
