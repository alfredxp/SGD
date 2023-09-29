using Microsoft.EntityFrameworkCore;
using SGDApi.Models;

namespace SGDApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<LogActividades> LogActividades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Server = (localdb)\ProjectModels; Database = RealEstateDb;";
            string connectionString = @"Server = (localdb)\Local; Database = SGDApi;";
            optionsBuilder.UseSqlServer(connectionString);
        }

    }


}
