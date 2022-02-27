using Microsoft.EntityFrameworkCore;
using OA.Domain;

namespace OA.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Id).ValueGeneratedNever();
            modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}