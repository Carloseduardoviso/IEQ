using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

public class IgrejaConfig : IEntityTypeConfiguration<Igreja>
{
    public void Configure(EntityTypeBuilder<Igreja> builder)
    {
        builder.ToTable("Igreja");

        builder.HasKey(i => i.IgrejaId);

        builder.Property(i => i.Nome)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(i => i.Endereco)
               .HasMaxLength(200);

        builder.HasOne(i => i.Regiao)
               .WithMany(r => r.Igrejas)
               .HasForeignKey(i => i.RegiaoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
