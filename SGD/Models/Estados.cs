using System.ComponentModel.DataAnnotations;

namespace SGD.Models
{
    public class Estados
    {
       [Key]
       public int EST_ID {get;set;}
       public string EST_NOMBRE { get; set; }
    }
}
