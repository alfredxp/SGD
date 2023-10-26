namespace SGDApi.Models
{
    public class Elecciones
    {
        public int Id { get; set; }

        public DateTime ElectionDate { get; set; }

        // Otros atributos relacionados con las elecciones

        // Propiedades de navegación
        public ICollection<Candidato> Candidates { get; set; }
    }
}
