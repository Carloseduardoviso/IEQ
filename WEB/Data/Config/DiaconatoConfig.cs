using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class DiaconatoConfig : IEntityTypeConfiguration<Diaconato>
    {
        public void Configure(EntityTypeBuilder<Diaconato> builder)
        {
            builder.ToTable("Diaconato");

            builder.HasKey(d => d.DiaconatoId);

            builder.Property(d => d.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Cargo)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(d => d.Contato)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(d => d.Estado)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(d => d.Cidade)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Ativo)
                   .HasDefaultValue(true);

            builder.HasOne(d => d.Igreja)
                   .WithMany(i => i.Diaconos)
                   .HasForeignKey(d => d.IgrejaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Regiao)
                   .WithMany(r => r.Diaconos)
                   .HasForeignKey(d => d.RegiaoId)
                   .OnDelete(DeleteBehavior.Restrict);
         
        }
    }
}
