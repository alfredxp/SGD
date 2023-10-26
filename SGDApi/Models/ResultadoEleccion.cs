using static System.Collections.Specialized.BitVector32;

namespace SGDApi.Models
{
    public class ResultadoEleccion
    {
        public int Id { get; set; }

        // Relaciones con otras tablas
        public int ElectionId { get; set; }
        public virtual Elecciones Election { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidato Candidate { get; set; }

        public int VotesObtained { get; set; }
    }
}
