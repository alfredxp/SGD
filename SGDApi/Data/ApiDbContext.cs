using Microsoft.EntityFrameworkCore;
using SGDApi.Models;

namespace SGDApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<LogActividades> LogActividades { get; set; }

    }
}
