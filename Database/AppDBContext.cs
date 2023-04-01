using Microsoft.EntityFrameworkCore;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"DataSource=app.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Password).HasMaxLength(500);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.CompanyId).HasMaxLength(250);
                entity.Property(e => e.Score).HasMaxLength(250);
                entity.Property(e => e.Achievements).HasMaxLength(250);

                entity.HasData(new UserDto
                {
                    Name = "Andrei",
                    Id = 1,
                    Email = "andrei@cercopitechs.com",
                    Password = "parola123",
                    CompanyId = "123",
                    Achievements = "000000"
                });

            });
        }
    }
}
