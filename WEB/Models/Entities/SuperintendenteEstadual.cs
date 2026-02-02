namespace WEB.Models.Entities
{
    public class SuperintendenteEstadual
    {
        public Guid SuperintendenteEstadualId { get; set; }

        public string Nome { get; set; } = null!;

        public ICollection<Regiao> Regioes { get; set; } = new List<Regiao>();
    }
}
