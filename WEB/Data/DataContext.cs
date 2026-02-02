using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WEB.Data.Config;
using WEB.Models.Entities;

namespace WEB.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Diaconato> Diaconatos { get; set; }
        public DbSet<Igreja> Igrejas  { get; set; }
        public DbSet<Pastores> Pastores { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<SuperintendenteEstadual> SuperintendenteEstaduals { get; set; }
        public DbSet<SuperintendenteRegional> SuperintendenteRegionals { get; set; }
        public DbSet<Membro> Membros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiaconatoConfig());
            modelBuilder.ApplyConfiguration(new IgrejaConfig());
            modelBuilder.ApplyConfiguration(new PastoresConfig());
            modelBuilder.ApplyConfiguration(new RegiaoConfig());
            modelBuilder.ApplyConfiguration(new SuperintendenteEstadualConfig());
            modelBuilder.ApplyConfiguration(new SuperintendenteRegionalConfig());
            modelBuilder.ApplyConfiguration(new MembroConfig());            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
