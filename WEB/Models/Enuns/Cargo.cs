using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum Cargo
    {
        [Display(Name = "Membro")]
        Membros = 1,

        [Display(Name = "Diácono")]
        Diacono = 2,

        [Display(Name = "Diaconisa")]
        Diaconisa = 3,

        [Display(Name = "Louvor")]
        Louvor = 4,

        [Display(Name = "Criança")]
        Crianca = 5,

        [Display(Name = "Homens")]
        Homem = 6,

        [Display(Name = "Mulheres")]
        Mulher = 7,

        [Display(Name = "Jovem")]
        Jovem = 8,

        [Display(Name = "Adolescente")]
        Adolescente = 9,

        [Display(Name = "Teatro")]
        Teatro = 10,

        [Display(Name = "Missão")]
        Missao = 11,

        [Display(Name = "Líder")]
        Lider = 12,

        [Display(Name = "Vice Líder")]
        PastorTitular = 13,

        [Display(Name = "Pastor Titular")]
        ViceLider = 14,

        [Display(Name = "Pastor Auxiliar")]
        PastorAuxiliar = 15,

        [Display(Name = "Diretor")]
        Diretor = 16,

        [Display(Name = "Diretora")]
        Diretora = 17,

        [Display(Name = "Coordenador Regional")]
        CoordenadorRegional = 16,
    }
}