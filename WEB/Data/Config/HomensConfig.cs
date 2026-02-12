using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class HomensConfig : IEntityTypeConfiguration<Homens>
    {
        public void Configure(EntityTypeBuilder<Homens> builder)
        {
            builder.ToTable(nameof(Homens));
            builder.HasKey(h => h.HomensId);

            builder.Property(d => d.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CargoLocal).IsRequired().HasMaxLength(80);
            builder.Property(d => d.CargoRegional).IsRequired().HasMaxLength(80);
            builder.Property(d => d.Estado).IsRequired().HasMaxLength(2);
            builder.Property(d => d.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Ativo).HasDefaultValue(true);

            builder.HasOne(d => d.Igreja).WithMany(i => i.Homens).HasForeignKey(d => d.IgrejaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Regiao).WithMany(r => r.Homens).HasForeignKey(d => d.RegiaoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}