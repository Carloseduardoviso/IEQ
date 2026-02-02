namespace WEB.Models.Entities
{
    public class Membro
    {
        public Guid MembroId { get; set; }

        public string NomeCompleto { get; set; } = null!;
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public DateTime? DataNascimento { get; set; }
        public DateTime? DataBatismo { get; set; }

        public string? Estado { get; set; }
        public string? Cidade { get; set; }

        public bool Ativo { get; set; } = true;

        // 🔹 FOTO
        public string? FotoUrl { get; set; }

        // 🔹 RELACIONAMENTO
        public Guid IgrejaId { get; set; }
        public Igreja Igreja { get; set; } = null!;
    }
}
