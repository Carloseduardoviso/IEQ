using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

public class SuperintendenteEstadualConfig : IEntityTypeConfiguration<SuperintendenteEstadual>
{
    public void Configure(EntityTypeBuilder<SuperintendenteEstadual> builder)
    {
        builder.ToTable("SuperintendenteEstadual");

        builder.HasKey(s => s.SuperintendenteEstadualId);

        builder.Property(s => s.Nome)
               .IsRequired()
               .HasMaxLength(150);
    }
}
