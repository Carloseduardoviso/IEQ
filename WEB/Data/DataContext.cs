using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WEB.Data.Config;
using WEB.Models.Entities;

namespace WEB.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Diaconato> Diaconatos { get; set; }
        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Pastores> Pastores { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<SuperintendenteEstadual> SuperintendenteEstaduals { get; set; }
        public DbSet<SuperintendenteRegional> SuperintendenteRegionals { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Crianca> Criancas { get; set; }
        public DbSet<Homens> Homens { get; set; }
        public DbSet<JovemAdolescente> Adolescentes { get; set; }
        public DbSet<Louvor> Louvores { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Mulheres> Mulheres { get; set; }
        public DbSet<Teatro> Teatros { get; set; }
        public DbSet<Danca> Dancas { get; set; }
        public DbSet<Casal> Casals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiaconatoConfig());
            modelBuilder.ApplyConfiguration(new IgrejaConfig());
            modelBuilder.ApplyConfiguration(new PastoresConfig());
            modelBuilder.ApplyConfiguration(new RegiaoConfig());
            modelBuilder.ApplyConfiguration(new SuperintendenteEstadualConfig());
            modelBuilder.ApplyConfiguration(new SuperintendenteRegionalConfig());
            modelBuilder.ApplyConfiguration(new MembroConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new CriancaConfig());
            modelBuilder.ApplyConfiguration(new HomensConfig());
            modelBuilder.ApplyConfiguration(new JovemAdolescenteConfig());
            modelBuilder.ApplyConfiguration(new LouvorConfig());
            modelBuilder.ApplyConfiguration(new MidiaConfig());
            modelBuilder.ApplyConfiguration(new MulheresConfig());
            modelBuilder.ApplyConfiguration(new TeatroConfig());
            modelBuilder.ApplyConfiguration(new DancaConfig());
            modelBuilder.ApplyConfiguration(new CasalConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}