namespace SGDApi.Models
{
    public class VotingRecord
    {
        public int Id { get; set; }

        // Relaciones con otras tablas
        public int VoterId { get; set; }
        public virtual Votante Voter { get; set; }

        public string RegistrationRecord { get; set; }

        public bool PriorVotingHistory { get; set; }
    }
}
