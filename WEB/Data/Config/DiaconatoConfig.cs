using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class DiaconatoConfig : IEntityTypeConfiguration<Diaconato>
    {
        public void Configure(EntityTypeBuilder<Diaconato> builder)
        {
            builder.ToTable(nameof(Diaconato));
            builder.HasKey(d => d.DiaconatoId);

            builder.Property(d => d.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CargoLocal).IsRequired().HasMaxLength(80);
            builder.Property(d => d.CargoRegional).HasMaxLength(80);
            builder.Property(d => d.Estado).IsRequired().HasMaxLength(2);
            builder.Property(d => d.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Ativo).HasDefaultValue(true);

            builder.HasOne(d => d.Igreja).WithMany(i => i.Diaconos).HasForeignKey(d => d.IgrejaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Regiao).WithMany(r => r.Diaconos).HasForeignKey(d => d.RegiaoId).OnDelete(DeleteBehavior.Cascade);         
        }
    }
}
