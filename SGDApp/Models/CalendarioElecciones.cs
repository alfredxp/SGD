namespace SGDApp.Models
{
    public class CalendarioElecciones
    {
        public int Id { get; set; }

        // Relaciones con otras tablas (por ejemplo, elecciones relacionadas)

        public DateTime KeyDate { get; set; }

        public string Description { get; set; }
    }
}
