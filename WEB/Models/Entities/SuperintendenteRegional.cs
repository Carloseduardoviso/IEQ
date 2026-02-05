namespace WEB.Models.Entities
{
    public class SuperintendenteRegional
    {
        public Guid SuperintendenteRegionalId { get; set; }

        public string Nome { get; set; } = null!; 
        public bool Ativo { get; set; } = true;


        public ICollection<Regiao> Regioes { get; set; } = new List<Regiao>();
    }
}
