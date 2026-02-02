using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class MembroVm
    {
        public Guid MembroId { get; set; }

        [Display(Name = "Nome Completo")]
        [Required]
        [MaxLength(150)]
        public string? NomeCompleto { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(14)]
        public string? CPF { get; set; }

        [Phone]
        public string? Telefone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Data de Batismo")]
        public DateTime? DataBatismo { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public string? Cidade { get; set; }

        public bool Ativo { get; set; } = true;

        // 🔹 FOTO
        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }

        // 🔹 IGREJA
        [Display(Name = "Igreja")]
        [Required]
        public Guid IgrejaId { get; set; }

        public IgrejaVm? Igreja { get; set; }
    }
}
