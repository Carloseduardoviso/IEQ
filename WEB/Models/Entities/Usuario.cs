using System.ComponentModel.DataAnnotations;
using WEB.Models.Enuns;

namespace WEB.Models.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        // SOMENTE HASH
        [MaxLength(500)]
        public string? SenhaHash { get; set; }
        public bool Ativo { get; set; } = true;

        [Required]
        public Role Role { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? UltimoLogin { get; set; }
        public string? FotoUrl { get; set; }
        public Genero Genero { get; set; }
        public Membro? Membro { get; set; }
    }
}