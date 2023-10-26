using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SGDApp.Models
{
    public class Task
    {
        
        public int TaskId { get; set; }

        public string? TaskName { get; set; }
        public DateTime? FechaUltimaRevision { get; set; }
        public DateTime? FechaOrigen { get; set; }
        public Collection<Estados>? Estados { get; set; }
        public string? Descripcion { get; set; }
        public Collection<Comentario>? Comentarios { get; set; }

        [JsonIgnore]
        public Collection<LogActividades>? LogActividades { get; set; }

        public int AreaId { get; set; }
        public Area? Area { get; set; }

        public int DocumentoId { get; set; }
        public Documento? Documento { get; set; }

        public int UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }

        
        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }
        
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }
    }
}
