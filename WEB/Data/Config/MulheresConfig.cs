using Microsoft.EntityFrameworkCore;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class MulheresConfig : IEntityTypeConfiguration<Mulheres>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Mulheres> builder)
        {
            builder.ToTable(nameof(Mulheres));
            builder.HasKey(m => m.MulheresId);

            builder.Property(d => d.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CargoLocal).IsRequired().HasMaxLength(80);
            builder.Property(d => d.CargoRegional).HasMaxLength(80);
            builder.Property(d => d.Estado).IsRequired().HasMaxLength(2);
            builder.Property(d => d.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Ativo).HasDefaultValue(true);

            builder.HasOne(d => d.Igreja).WithMany(i => i.Mulheres).HasForeignKey(d => d.IgrejaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Regiao).WithMany(r => r.Mulheres).HasForeignKey(d => d.RegiaoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}