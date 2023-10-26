using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApp.Models
{
    public class Estados
    {
        
        public int EstadoId { get; set; }
        
        public string? EstadoNombre { get; set; }
        
        public string? EstadoCodigo { get; set; }

        
        public int? TaskId { get; set; }
        public virtual Task? Task { get; set; }

        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }

        
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }



    }
}
