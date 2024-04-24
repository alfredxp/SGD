using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Reportes
    {
        [Key]
        public int RPT_ID { get; set; }
        public string RPT_NOMBRE { get; set; }
        public string RPT_DESCRIPCION { get; set; }
        public DateTime RPT_FECHACREACION { get; set; }
        public DateTime RPT_FECHAMODIFICACION { get; set; }
        public int CTG_ID { get; set; }
        public int EST_ID { get; set; }
        public int USR_ID { get; set; }
    }
}
