using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB.Models.Entities;

namespace WEB.Data.Config
{
    public class DiaconatoConfig : IEntityTypeConfiguration<Diaconato>
    {
        public void Configure(EntityTypeBuilder<Diaconato> builder)
        {
            builder.ToTable(nameof(Diaconato));
            builder.HasKey(d => d.DiaconatoId);

            builder.Property(d => d.NomeCompleto).IsRequired();
            builder.Property(d => d.Regiao).IsRequired();
            builder.Property(d => d.Igreja).IsRequired();
            builder.Property(d => d.Cargo).IsRequired();
            builder.Property(d => d.Contato).IsRequired();
            builder.Property(d => d.NomePastor).IsRequired();
            builder.Property(d => d.DataNascimento).IsRequired();
            builder.Property(d => d.DataMinisterio);
            builder.Property(d => d.DataBatismo);
            builder.Property(d => d.Ativo);
            builder.Property(d => d.FotoUrl);
        }
    }
}