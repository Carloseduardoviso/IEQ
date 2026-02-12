using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum CargoRegional
    {
        [Display(Name = "Superintendente Regional")]
        SuperintendenteRegional = 1,

        // Coordenadores Regionais
        [Display(Name = "Coordenador Regional Diaconato")]
        CoordenadorRegionalDiaconato = 2,
        [Display(Name = "Coordenador Regional Louvor")]
        CoordenadorRegionalLouvor = 3,
        [Display(Name = "Coordenador Regional Homens")]
        CoordenadorRegionalHomens = 4,
        [Display(Name = "Coordenador Regional Mulher")]
        CoordenadorRegionalMulher = 5,
        [Display(Name = "Coordenador Regional Mídia")]
        CoordenadorRegionalMidia = 6,
        [Display(Name = "Coordenador Regional Teatro")]
        CoordenadorRegionalTeatro = 7,
        [Display(Name = "Coordenador Regional Criança")]
        CoordenadorRegionalCrianca = 8,
        [Display(Name = "Coordenador Regional Jovem/Adolescente")]
        CoordenadorRegionalJovemAdolescente = 9,
        [Display(Name = "Coordenador Regional Missão")]
        CoordenadorRegionalMissao = 10,
    }
}