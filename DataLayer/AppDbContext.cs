﻿using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Server=localhost;Database=DAWM_LabProject;Trusted_Connection=True;MultipleActiveResultSets=True")
                    .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>().Property(e => e.Name).HasMaxLength(10);

            modelBuilder.Entity<User>()
                .HasDiscriminator(m => m.Role)
                .HasValue<Student>("Student")
                .HasValue<Professor>("Professor");
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
