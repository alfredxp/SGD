using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Departamentos
    {
        [Key]
        public int DEPT_ID { get; set; }
        public string DEPT_NOMBRE { get; set; }
        public string DEPT_DESCRIPCION { get; set; }
        public DateTime DEPT_FECHACREACION { get; set; }
        public DateTime DEPT_FECHAMODIFICACION { get; set; }
        public int USR_ID { get; set; }
        public int EST_ID { get; set; }
    }
}
