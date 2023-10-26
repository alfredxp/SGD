namespace SGDApi.Models
{
    public class ComunicacionesOficiales
    {
        public int Id { get; set; }

        public string CommunicationType { get; set; }

        public string CommunicationContent { get; set; }

        public DateTime SentDate { get; set; }
    }
}
