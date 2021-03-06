using System;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace Datos
{
    public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacuna>()
            .HasOne<Persona>().WithMany()
            .HasForeignKey(p => p.CedulaPersona);
        }
    }
}
