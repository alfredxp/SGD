using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Roles
    {
        [Key]
        public int ROL_ID { get; set; }
        public string ROL_NOMBRE { get; set; }
        public string ROL_DESCRIPCION { get; set; }
        public int EST_ID { get; set; }
    }
}
