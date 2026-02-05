using System.ComponentModel.DataAnnotations;
using WEB.Models.ViewModels;

public class IgrejaVm
{
    public Guid IgrejaId { get; set; }

    [Required]
    [MaxLength(150)]
    [Display(Name = "Nome da Igreja")]
    public string? Nome { get; set; }


    [Required]
    [Display(Name = "Região")]
    public Guid RegiaoId { get; set; }
    public bool Ativo { get; set; } = true;

    public RegiaoVm? Regiao { get; set; }

    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }
}
