using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApi.Models
{
    public class Estados
    {
        [Key]
        [Column("EstadoId")]
        public int EstadoId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? EstadoNombre { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string? EstadoCodigo { get; set; }

        [ForeignKey(nameof(Task))]
        public int? TaskId { get; set; }
        public virtual Task? Task { get; set; }

        [ForeignKey(nameof(UsuarioModificacion))]
        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }

        [ForeignKey(nameof(UsuarioCreador))]
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }



    }
}
