using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence
{
    public class SiaseDbContext : DbContext
    {
        public SiaseDbContext( DbContextOptions<SiaseDbContext> options ) : base(options) { }

        public DbSet<Materia> Materia { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Carrera> Carrera { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
