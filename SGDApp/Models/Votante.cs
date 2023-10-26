using System.ComponentModel.DataAnnotations;

namespace SGDApp.Models
{
    public class Votante
    {
        public int Id { get; set; }

        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        // Otros detalles relevantes

        // Propiedad de navegación opcional si tienes relaciones con otras tablas
        public ICollection<Elecciones> Elections { get; set; }
    }
}
