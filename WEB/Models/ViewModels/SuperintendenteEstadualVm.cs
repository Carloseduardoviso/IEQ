using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class SuperintendenteEstadualVm
    {
        public Guid SuperintendenteEstadualId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(150)]
        public string? Nome { get; set; }
        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;

    }
}
