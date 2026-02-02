using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class PastoresConfig : IEntityTypeConfiguration<Pastores>
    {
        public void Configure(EntityTypeBuilder<Pastores> builder)
        {
            builder.ToTable("Pastores");

            builder.HasKey(p => p.PastorId);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Telefone)
                   .HasMaxLength(20);

            builder.Property(p => p.Email)
                   .HasMaxLength(150);

            builder.HasOne(p => p.Igreja)
                   .WithMany(i => i.Pastores)
                   .HasForeignKey(p => p.IgrejaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
