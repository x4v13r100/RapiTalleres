using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapiTalleres.Models;

namespace RapiTalleres.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext (DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tecnico>().ToTable("Tecnico");
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Servicio>().ToTable("Servicio");
        }
    }
}
