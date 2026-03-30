using System.ComponentModel.DataAnnotations;
using WEB.Models.Enuns;

namespace WEB.Models.ViewModels
{
    public class UsuarioVm
    {
        public Guid UsuarioId { get; set; }

        public Guid? SuperintendenteEstadualId { get; set; }
        public Guid? SuperintendenteRegionalId { get; set; }

        [Display(Name = "Pastor")]
        public Guid? PastorId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }

        // Opcional na edição
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
        public string? Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        public string? ConfirmarSenha { get; set; }

        [Display(Name = "Região")]
        public Guid? RegiaoId { get; set; }

        [Display(Name = "Igreja")]
        public Guid? IgrejaId { get; set; }

        [Required]
        public Role Role { get; set; } = Role.Membro;
        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; }
        [Required]
        public string? Contato { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public string? Cidade { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Required]
        [Display(Name = "Entrada na Igreja")]
        public DateTime? DataMinisterio { get; set; }
        [Display(Name = "Data de Batismo")]
        public DateTime? DataBatismo { get; set; }
    }
}