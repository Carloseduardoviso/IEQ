using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum Genero
    {
        [Display(Name = "Homens")]
        Homens = 1,
        [Display(Name = "Mulheres")]
        Mulheres = 2
    }
}
