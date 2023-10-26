namespace SGDApi.Models
{
    public class CampaignDocument
    {
        public int Id { get; set; }

        // Relaciones con otras tablas
        public int CandidateId { get; set; }
        public virtual Candidato Candidate { get; set; }

        public string DocumentType { get; set; } // Puedes definir tipos de documento específicos

        public string DocumentContent { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
