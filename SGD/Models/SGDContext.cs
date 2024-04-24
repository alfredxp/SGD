using Microsoft.EntityFrameworkCore;

namespace SGD.Models
{
    public class SGDContext : DbContext
    {

        public SGDContext(DbContextOptions<SGDContext> options) : base(options)
        {
        }

        public DbSet<Task> tasks { get; set; }
        public DbSet<Actividades> actividades { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Estados> estados { get; set; }
        public DbSet<Reportes> reportes { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

    }
}
