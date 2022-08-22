using Microsoft.EntityFrameworkCore;
using Music_Library.Entities;

namespace Music_Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {


        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS;Database=MusicDb;Trusted_Connection=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Purchased> Purchased { get; set; }
        public DbSet<Artist> Artist { get; set; }

    }
}
