using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum CargoLocal
    {
        [Display(Name = "Membro")]
        Membro = 1,

        [Display(Name = "Homens")]
        Homens = 2,

        [Display(Name = "Mulheres")]
        Mulheres = 3,

        [Display(Name = "Jovem")]
        Jovem = 4,

        [Display(Name = "Adolescente")]
        Adolescente = 5,

        [Display(Name = "Criança")]
        Crianca = 6,

        [Display(Name = "Louvor")]
        Louvor = 7,

        [Display(Name = "Missão")]
        Missao = 8,

        [Display(Name = "Mídia")]
        Midia = 9,

        [Display(Name = "Teatro")]
        Teatro = 10,

        [Display(Name = "Dança")]
        Danca = 11,

        [Display(Name = "Diácono")]
        Diacono = 12,

        [Display(Name = "Diaconisa")]
        Diaconisa = 13,

        [Display(Name = "Diretor")]
        Diretor = 14,

        [Display(Name = "Diretora")]
        Diretora = 15,

        [Display(Name = "Líder")]
        Lider = 16,

        [Display(Name = "Vice Líder")]
        ViceLider = 17,

        [Display(Name = "Secretário")]
        Secretario = 18,

        [Display(Name = "Secretária")]
        Secretaria = 19,

        [Display(Name = "Tesoureiro")]
        Tesoureiro = 20,

        [Display(Name = "Tesoureira")]
        Tesoureira = 21,

        [Display(Name = "Pastor(a)")]
        Pastor = 22,

        [Display(Name = "Pastor(a) Auxiliar")]
        PastorAuxiliar = 23
    }
}
