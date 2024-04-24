using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Task
    {
        [Key]
        public int TSK_ID { get; set; }
        public string TSK_NOMBRE { get; set; }
        public string TSK_DESCRIPCION { get; set; }
        public DateTime TSK_FECHAINICIO { get; set; }
        public DateTime TSK_FECHAFINAL { get; set; }
        public int USR_ID { get; set; }
        public int EST_ID { get; set; }
    }
}
