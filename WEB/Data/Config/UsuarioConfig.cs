using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.UsuarioId);
            builder.Property(u => u.NomeCompleto).HasMaxLength(150).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.SenhaHash).HasMaxLength(255);
            builder.Property(u => u.Ativo).IsRequired();
            builder.Property(u => u.Role).IsRequired().HasConversion<int>();
            builder.Property(u => u.DataCriacao).IsRequired();
            builder.Property(u => u.Genero).IsRequired();

        }
    }
}