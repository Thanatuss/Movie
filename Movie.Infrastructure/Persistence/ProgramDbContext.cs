using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            // Convert List<string> <-> string (CSV) برای Cast
            var stringListConverter = new ValueConverter<List<string>, string>(
                v => string.Join(", ", v), // ذخیره در DB
                v => v.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList() // لود از DB
            );

            modelBuilder.Entity<Movie.Domain.Entities.Movie>()
                .Property(m => m.Cast)
                .HasConversion(stringListConverter);

            // اپلای کردن تنظیمات دیگر
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgramDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
