namespace WEB.Models.Entities
{
    public class SuperintendenteEstadual
    {
        public Guid SuperintendenteEstadualId { get; set; }

        public string Nome { get; set; } = null!;
        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Regiao> Regioes { get; set; } = new List<Regiao>();
        public ICollection<Diaconato>? Diaconos { get; set; } = new List<Diaconato>();

    }
}
