using System.ComponentModel.DataAnnotations;

namespace SGDApi.Models
{
    public class LogActividades
    {
        [Key]
        public int LogActividadId { get; set; }

        public DateTime? LogActividadFecha { get; set; }

        public string LogActividadAccion { get; set; }

        public int UsuarioId {get;set;} 

        public virtual Usuarios Usuarios { get; set; }
    }
}
