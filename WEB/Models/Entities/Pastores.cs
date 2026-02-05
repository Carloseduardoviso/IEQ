using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Entities
{
    public class Pastores
    {
        public Guid PastorId { get; set; }

        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public Guid IgrejaId { get; set; }
        public bool Ativo { get; set; } = true;

        public Igreja Igreja { get; set; } = null!;
    }
}
