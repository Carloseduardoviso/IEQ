using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro = 1,

        [Display(Name = "Casado(a)")]
        Casado = 2,

        [Display(Name = "Divorciado(a)")]
        Divorciado = 3,

        [Display(Name = "Viúvo(a)")]
        Viuvo = 4,

        [Display(Name = "União Estável")]
        UniaoEstavel = 5
    }
}