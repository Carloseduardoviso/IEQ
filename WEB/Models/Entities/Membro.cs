using WEB.Models.Enuns;

namespace WEB.Models.Entities
{
    public class Membro
    {
        public Guid MembroId { get; set; }
        public Guid IgrejaId { get; set; }
        public Guid RegiaoId { get; set; }
        public Guid? PastorId { get; set; }
        public Guid? SuperintendenteEstadualId { get; set; }
        public Guid? SuperintendenteRegionalId { get; set; }
        public string? NomeCompleto { get; set; }  
        public string? Contato { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataMinisterio { get; set; }
        public DateTime? DataBatismo { get; set; }
        public int TempoAcumuladoEmMeses { get; set; } = 0;
        public DateTime? DataReativacao { get; set; }
        public DateTime? DataInativacao { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }

        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;
        public CargoLocal CargoLocal { get; set; }
        public CargoRegional? CargoRegional { get; set; }

        public Igreja? Igreja { get; set; }
        public Regiao? Regiao { get; set; }
        public Pastores? Pastor { get; set; }
        public SuperintendenteEstadual? SuperintendenteEstadual { get; set; }
        public SuperintendenteRegional? SuperintendenteRegional { get; set; }

        public Casal? Casal { get; set; }
        public Crianca? Crianca { get; set; }
        public Danca? Danca { get; set; }
        public Diaconato? Diaconato { get; set; }
        public Homens? Homens { get; set; }
        public JovemAdolescente? JovemAdolescente { get; set; }
        public Louvor? Louvor { get; set; }
        public Midia? Midia { get; set; }
        public Mulheres? Mulheres { get; set; }
        public Teatro? Teatro { get; set; }        
    }
}