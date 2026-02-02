using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class MembroConfig : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membro");

            builder.HasKey(m => m.MembroId);

            builder.Property(m => m.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(m => m.CPF)
                   .HasMaxLength(14);

            builder.Property(m => m.Telefone)
                   .HasMaxLength(20);

            builder.Property(m => m.Email)
                   .HasMaxLength(150);

            builder.Property(m => m.Estado)
                   .HasMaxLength(2);

            builder.Property(m => m.Cidade)
                   .HasMaxLength(100);

            builder.Property(m => m.Ativo)
                   .HasDefaultValue(true);

            // 🔹 RELACIONAMENTO
            builder.HasOne(m => m.Igreja)
                   .WithMany()
                   .HasForeignKey(m => m.IgrejaId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔹 ÍNDICES
            builder.HasIndex(m => m.NomeCompleto);
            builder.HasIndex(m => m.CPF).IsUnique();
        }
    }
}
