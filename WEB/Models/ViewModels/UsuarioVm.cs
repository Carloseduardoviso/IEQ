using System.ComponentModel.DataAnnotations;
using WEB.Models.Enuns;

namespace WEB.Models.ViewModels
{
    public class UsuarioVm
    {
        public Guid UsuarioId { get; set; }


        [Required(ErrorMessage = "Nome Completo é obrigatório")]
        public string? NomeCompleto { get; set; }

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

        [Required]
        public Role Role { get; set; } = Role.Membro;
        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; }
        public Genero Genero { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public MembroVm? Membro { get; set; }
    }
}