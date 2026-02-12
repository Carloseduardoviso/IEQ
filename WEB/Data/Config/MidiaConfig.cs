using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class MidiaConfig : IEntityTypeConfiguration<Midia>
    {
        public void Configure(EntityTypeBuilder<Midia> builder)
        {
            builder.ToTable(nameof(Midia));
            builder.HasKey(m => m.MidiaId);

            builder.Property(d => d.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CargoLocal).IsRequired().HasMaxLength(80);
            builder.Property(d => d.CargoRegional).HasMaxLength(80);
            builder.Property(d => d.Estado).IsRequired().HasMaxLength(2);
            builder.Property(d => d.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Ativo).HasDefaultValue(true);

            builder.HasOne(d => d.Igreja).WithMany(i => i.Midias).HasForeignKey(d => d.IgrejaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Regiao).WithMany(r => r.Midias).HasForeignKey(d => d.RegiaoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
