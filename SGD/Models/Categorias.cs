using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Categorias
    {
        [Key]
        public int CTG_ID { get; set; }
        public string CTG_NOMBRE { get; set; }
        public string CTG_DESCRIPCION { get; set; }
        public int EST_ID { get; set; }
        public int USR_ID { get; set; }
    }
}
