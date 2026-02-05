using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum Role
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Superintendente Estadual")]
        SuperintendenteEstadual = 2,

        [Display(Name = "Superintendente Regional")]
        SuperintendenteRegional = 3,

        [Display(Name = "Coordenador")]
        Coordenador = 4,

        [Display(Name = "Diretor")]
        Diretor = 5,

        [Display(Name = "Membro")]
        Membro = 6
    }
}