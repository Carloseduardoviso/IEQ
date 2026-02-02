using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

public class SuperintendenteRegionalConfig : IEntityTypeConfiguration<SuperintendenteRegional>
{
    public void Configure(EntityTypeBuilder<SuperintendenteRegional> builder)
    {
        builder.ToTable("SuperintendenteRegional");

        builder.HasKey(s => s.SuperintendenteRegionalId);

        builder.Property(s => s.Nome)
               .IsRequired()
               .HasMaxLength(150);
    }
}
