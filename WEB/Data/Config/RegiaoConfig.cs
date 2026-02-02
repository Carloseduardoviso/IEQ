using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

public class RegiaoConfig : IEntityTypeConfiguration<Regiao>
{
    public void Configure(EntityTypeBuilder<Regiao> builder)
    {
        builder.ToTable("Regiao");

        builder.HasKey(r => r.RegiaoId);

        builder.Property(r => r.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasOne(r => r.SuperintendenteRegional)
               .WithMany(s => s.Regioes)
               .HasForeignKey(r => r.SuperintendenteRegionalId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(r => r.SuperintendenteEstadual)
               .WithMany(s => s.Regioes)
               .HasForeignKey(r => r.SuperintendenteEstadualId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
