using static System.Collections.Specialized.BitVector32;

namespace SGDApi.Models
{
    public class ElectionComittee
    {
        public int Id { get; set; }

        public string CommitteeName { get; set; }

        // Relaciones con otras tablas
        public ICollection<Elecciones> Elections { get; set; }

    }
}
