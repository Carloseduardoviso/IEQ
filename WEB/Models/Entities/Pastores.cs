namespace WEB.Models.Entities
{
    public class Pastores
    {
        public Guid PastorId { get; set; }

        public string Nome { get; set; } = null!;
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public Guid IgrejaId { get; set; }
        public Igreja Igreja { get; set; } = null!;

        public ICollection<Diaconato> Diaconos { get; set; } = new List<Diaconato>();
    }
}
