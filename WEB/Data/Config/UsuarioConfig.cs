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
            builder.Property(u => u.Nome).HasMaxLength(150).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.SenhaHash).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Ativo).IsRequired();
            builder.Property(u => u.Role).IsRequired().HasConversion<int>();
            builder.Property(u => u.DataCriacao).IsRequired();

            builder.HasOne(u => u.Regiao).WithMany(r => r.Usuarios).HasForeignKey(u => u.RegiaoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.Igreja).WithMany(i => i.Usuarios).HasForeignKey(u => u.IgrejaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
