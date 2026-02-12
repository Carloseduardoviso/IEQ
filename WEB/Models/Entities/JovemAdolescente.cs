using WEB.Models.Enuns;

namespace WEB.Models.Entities
{
    public class JovemAdolescente
    {
        public Guid JovemAdolecenteId { get; set; }
        public Guid IgrejaId { get; set; }
        public Guid RegiaoId { get; set; }
        public Guid? PastorId { get; set; }
        public Guid? SuperintendenteEstadualId { get; set; }
        public Guid? SuperintendenteRegionalId { get; set; }
        public string? NomeCompleto { get; set; }
        public CargoLocal CargoLocal { get; set; }
        public CargoRegional CargoRegional { get; set; }
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

        public Igreja? Igreja { get; set; }
        public Regiao? Regiao { get; set; }
        public Pastores? Pastor { get; set; }
        public SuperintendenteEstadual? SuperintendenteEstadual { get; set; }
        public SuperintendenteRegional? SuperintendenteRegional { get; set; }

    }
}
