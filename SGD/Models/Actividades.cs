using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Actividades
    {
        [Key]
        public int ACT_ID { get; set; }
        public string ACT_NOMBRE { get; set; }
        public string ACT_DESCRIPCION { get; set; }
        public string ACT_CODIGO { get; set; }
        public DateTime ACT_FECHACREACION { get; set; }
        public DateTime ACT_FECHAMODIFICACION { get; set; }
        public DateTime ACT_FECHA { get; set; }
        public int EST_ID { get; set; }
        public int USR_ID { get; set; }
    }
}
