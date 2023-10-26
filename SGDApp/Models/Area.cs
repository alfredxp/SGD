using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApp.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaUltimaRevision { get; set; }
        public DateTime? FechaOrigen { get; set; }
        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }
    }
}
