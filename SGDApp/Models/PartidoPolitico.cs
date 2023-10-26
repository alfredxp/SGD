using System.ComponentModel.DataAnnotations;

namespace SGDApp.Models
{
    public class PartidoPolitico
    {
        
        public int Id { get; set; }

        public string PartyName { get; set; }

        public string PartyLeader { get; set; }

        public string PartyPlatform { get; set; }

        public string RegistrationStatus { get; set; }
    }
}
