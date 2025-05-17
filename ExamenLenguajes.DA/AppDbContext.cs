using Microsoft.EntityFrameworkCore;
using ExamenLenguajes.Model;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;

namespace ExamenLenguajes.DA
{
    public class AppDbContext : DbContext
    {

    

        public DbSet<Apartamentos> Apartamentos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartamentos>().HasKey(e => e.Id);
        }
    }
}
