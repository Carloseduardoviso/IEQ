using System.ComponentModel.DataAnnotations;
using WEB.Models.Enuns;

namespace WEB.Models.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public Guid? RegiaoId { get; set; }
        public Guid? IgrejaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        public string? SenhaHash { get; set; }

        public bool Ativo { get; set; } = true;

        [Required]
        public Role Role { get; set; }


        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? UltimoLogin { get; set; }

        public Regiao? Regiao { get; set; }
        public Igreja? Igreja { get; set; }
    }
}
