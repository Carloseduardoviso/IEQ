namespace WEB.Models.Entities
{
    public class Regiao
    {
        public Guid RegiaoId { get; set; }

        public string Nome { get; set; } = null!;

        public Guid? SuperintendenteRegionalId { get; set; }
        public SuperintendenteRegional? SuperintendenteRegional { get; set; }

        public Guid? SuperintendenteEstadualId { get; set; }
        public SuperintendenteEstadual? SuperintendenteEstadual { get; set; }

        public ICollection<Igreja> Igrejas { get; set; } = new List<Igreja>();
        public ICollection<Diaconato> Diaconos { get; set; } = new List<Diaconato>();
    }
}
