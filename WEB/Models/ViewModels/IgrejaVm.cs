using System.ComponentModel.DataAnnotations;

public class IgrejaVm
{
    [Key]
    public Guid IgrejaId { get; set; }

    [Required]
    [MaxLength(150)]
    [Display(Name = "Nome da Igreja")]
    public string? Nome { get; set; }

    [Display(Name = "Código")]
    public string? Codigo { get; set; }

    [Required]
    [Display(Name = "Região")]
    public Guid RegiaoId { get; set; }
    public IFormFile? Foto { get; set; }
    public string? FotoUrl { get; set; }
    public bool Ativo { get; set; } = true;


    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }
    public RegiaoVm? Regiao { get; set; }
}
