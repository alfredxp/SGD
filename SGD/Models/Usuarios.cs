using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Usuarios
    {
        [Key]
        public int USR_ID { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_CORREO { get; set; }
        public string USR_CONTRASENA { get; set; }
        public string USR_IDENTIFICACION { get; set; }
        public string USR_TELEFONO { get; set; }
        public string USR_LLAVEQR { get; set; }
        public int USR_TWOFACTOR { get; set; }
        public int EST_ID { get; set; }
        public int ROL_ID { get; set; }
);
    }
}
