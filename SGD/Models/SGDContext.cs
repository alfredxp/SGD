using Microsoft.EntityFrameworkCore;

namespace SGD.Models
{
    public class SGDContext : DbContext
    {

        public SGDContext(DbContextOptions<SGDContext> options) : base(options)
        {
        }

        public DbSet<Task> tasks { get; set; }

    }
}
