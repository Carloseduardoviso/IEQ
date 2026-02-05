namespace WEB.Models.Entities
{
    public class Igreja
    {
        public Guid IgrejaId { get; set; }

        public string Nome { get; set; } = null!;
        public string? Endereco { get; set; }
        public Guid RegiaoId { get; set; }
        public bool Ativo { get; set; } = true;

        public Regiao Regiao { get; set; } = null!;
        public ICollection<Diaconato> Diaconos { get; set; } = new List<Diaconato>();
        public ICollection<Pastores> Pastores { get; set; } = new List<Pastores>();
    }
}
