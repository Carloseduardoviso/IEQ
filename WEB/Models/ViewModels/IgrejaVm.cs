using System.ComponentModel.DataAnnotations;
using WEB.Models.ViewModels;

public class IgrejaVm
{
    public Guid IgrejaId { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Nome { get; set; }

    [Required]
    public Guid RegiaoId { get; set; }
    public RegiaoVm? Regiao { get; set; }

    public string? Endereco { get; set; }
}
