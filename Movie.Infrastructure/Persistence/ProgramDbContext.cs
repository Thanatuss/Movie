using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;

namespace Movie.Infrastructure.Persistence
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Movie.Domain.Entities.Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // اپلای کردن Fluent Configurations از این اسمبلی (بهتر برای ساختار تمیز)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgramDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
