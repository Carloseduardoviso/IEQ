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
            builder.Property(d => d.DataInativacao);
            builder.Property(d => d.FotoUrl);
            builder.Property(d => d.FotoUrlConsagracao);
            builder.Property(d => d.FotoUrl5Anos);
            builder.Property(d => d.FotoUrl10Anos);
            builder.Property(d => d.FotoUrl15Anos);
            builder.Property(d => d.FotoUrl20Anos);
            builder.Property(d => d.FotoUrl25Anos);
            builder.Property(d => d.Ativo);
        }
    }
}