
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SGDApp.Models
{
    public class LogActividades
    {
        [Key]
        public int LogActividadId { get; set; }

        public DateTime? LogActividadFecha { get; set; }
        public string? LogActividadAccion { get; set; }

        public int? TaskId { get; set; }
        [JsonIgnore]
        public virtual Task? Task { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore]
        public virtual Usuarios? Usuarios { get; set; }
    }

}
