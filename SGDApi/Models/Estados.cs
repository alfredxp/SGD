using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApi.Models
{
    public class Estados
    {
        [Key]
        public int EstadoId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string EstadoNombre { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string EstadoCodigo { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
