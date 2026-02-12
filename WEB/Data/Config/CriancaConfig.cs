using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class CriancaConfig : IEntityTypeConfiguration<Crianca>
    {
        public void Configure(EntityTypeBuilder<Crianca> builder)
        {
            builder.ToTable(nameof(Crianca));
            builder.HasKey(c => c.CriancaId);

            builder.Property(d => d.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CargoLocal).IsRequired().HasMaxLength(80);
            builder.Property(d => d.CargoRegional).IsRequired().HasMaxLength(80);
            builder.Property(d => d.Estado).IsRequired().HasMaxLength(2);
            builder.Property(d => d.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Ativo).HasDefaultValue(true);

            builder.HasOne(d => d.Igreja).WithMany(i => i.Criancas).HasForeignKey(d => d.IgrejaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Regiao).WithMany(r => r.Criancas).HasForeignKey(d => d.RegiaoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}