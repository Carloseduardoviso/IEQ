using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class SuperintendenteRegionalVm
    {
        public Guid SuperintendenteRegionalId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(150)]
        public string? Nome { get; set; }
    }
}
