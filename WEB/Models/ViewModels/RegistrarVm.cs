using System.ComponentModel.DataAnnotations;
using WEB.Models.Entities;
using WEB.Models.Enuns;

namespace WEB.Models.ViewModels
{
    public class RegistrarVm
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Compare("Senha")]
        public string? ConfirmarSenha { get; set; }

        [Display(Name = "Região")]
        public Guid? RegiaoId { get; set; }

        [Display(Name = "Igreja")]
        public Guid? IgrejaId { get; set; }

        [Required]
        public Role Role { get; set; }

        public Regiao? Regiao { get; set; }
        public Igreja? Igreja { get; set; }

    }
}
