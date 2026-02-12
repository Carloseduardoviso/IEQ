using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;
using WEB.Models.Enuns;

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

            builder.Property(d => d.Cargos)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(d => d.Cargos)
            .HasConversion(
                v => string.Join(',', v),
                v => string.IsNullOrWhiteSpace(v) || v == "[]"
                        ? new List<Cargo>()
                        : v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => Enum.Parse<Cargo>(s))
                           .ToList()
            );

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
