using Microsoft.EntityFrameworkCore;
using SGDApi.Models;
using Task = SGDApi.Models.Task;

namespace SGDApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options) { }
        

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<LogActividades> LogActividades { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Server = (localdb)\mssqllocaldb; Database = SGDApi;";
            string connectionString = @"Server = (localdb)\mssqllocaldb; Database = SGDApi;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogActividades>()
        .HasOne(la => la.Usuarios) 
        .WithMany() 
        .HasForeignKey(la => la.UsuarioId)
        .HasConstraintName("FK_LogActividades_Usuarios_UsuarioId");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SGDApi.Models.CampaignDocument>? CampaignDocument { get; set; }

        public DbSet<SGDApi.Models.Candidato>? Candidato { get; set; }

        public DbSet<SGDApi.Models.CalendarioElecciones>? CalendarioElecciones { get; set; }

        public DbSet<SGDApi.Models.ComunicacionesOficiales>? ComunicacionesOficiales { get; set; }

        public DbSet<SGDApi.Models.Elecciones>? Eleciones { get; set; }

        public DbSet<SGDApi.Models.ElectionComittee>? ElectionComittee { get; set; }

        public DbSet<SGDApi.Models.HistorialElectoral>? HistorialElectoral { get; set; }

        public DbSet<SGDApi.Models.PartidoPolitico>? PartidoPolitico { get; set; }

        public DbSet<SGDApi.Models.ResultadoEleccion>? ResultadoEleccion { get; set; }

        public DbSet<SGDApi.Models.Votante>? Votante { get; set; }

        public DbSet<SGDApi.Models.VotingRecord>? VotingRecord { get; set; }
    }


}
