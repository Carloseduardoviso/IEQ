using System.ComponentModel.DataAnnotations;
using WEB.Models.ViewModels;

public class RegiaoVm
{
    public Guid RegiaoId { get; set; }

    [Required]
    public string? Nome { get; set; }

    public Guid? SuperintendenteRegionalId { get; set; }

    public Guid? SuperintendenteEstadualId { get; set; }
    public SuperintendenteRegionalVm? SuperintendenteRegional { get; set; }
    public SuperintendenteEstadualVm? SuperintendenteEstadual { get; set; }
}
