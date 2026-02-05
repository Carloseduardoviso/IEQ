using System.ComponentModel.DataAnnotations;

public class PastoresVm
{
    public Guid PastoresId { get; set; }

    [Required]
    public string? Nome { get; set; }

    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool Ativo { get; set; } = true;

    [Required]
    public Guid IgrejaId { get; set; }
    public IgrejaVm? Igreja { get; set; }
}
