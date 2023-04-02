using backend.DTOs;
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
        public DbSet<CompanyDto> Companies { get; set; }
        public DbSet<HistoryDto> Actions { get; set; }

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
                    CompanyId = "1",
                    Achievements = "000000"
                });
            });

            modelBuilder.Entity<CompanyDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Password).HasMaxLength(500);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Score).HasMaxLength(250);
                entity.Property(e => e.BusinessAchievements).HasMaxLength(250);

                entity.HasData(new CompanyDto
                {
                    Name = "Cercopitechs",
                    Id = 1,
                    Email = "support@cercopitechs.com",
                    Password = "parola123",
                    Score = 0,
                    BusinessAchievements = "000000"
                });
            });

            modelBuilder.Entity<HistoryDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.Date).HasMaxLength(250);
                entity.Property(e => e.PhotoPath).HasMaxLength(500);
                entity.Property(e => e.actionId).HasMaxLength(250);
  

                entity.HasData(new HistoryDto
                {
                    Date = new DateTime(),
                    Id = 1,
                    UserId = 1,
                    PhotoPath = "dummyPath",
                    actionId = 1
                });
            });
        }
    }
}
