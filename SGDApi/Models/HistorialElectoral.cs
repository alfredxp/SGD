using static System.Collections.Specialized.BitVector32;

namespace SGDApi.Models
{
    public class HistorialElectoral
    {
        public int Id { get; set; }

        // Relaciones con otras tablas
        public int CandidateId { get; set; }
        public virtual Candidato Candidate { get; set; }

        public ICollection<Elecciones> PreviousElections { get; set; }

    }
}
