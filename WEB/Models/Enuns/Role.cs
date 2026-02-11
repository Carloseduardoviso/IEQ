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

        // Coordenadores Regionais
        [Display(Name = "Coordenador Regional Diaconato")]
        CoordenadorRegionalDiaconato = 4,

        [Display(Name = "Coordenador Regional Louvor")]
        CoordenadorRegionalLouvor = 5,

        [Display(Name = "Coordenador Regional Homens")]
        CoordenadorRegionalHomens = 6,

        [Display(Name = "Coordenador Regional Mulher")]
        CoordenadorRegionalMulher = 7,

        [Display(Name = "Coordenador Regional Mídia")]
        CoordenadorRegionalMidia = 8,

        [Display(Name = "Coordenador Regional Teatro")]
        CoordenadorRegionalTeatro = 9,

        [Display(Name = "Coordenador Regional Criança")]
        CoordenadorRegionalCrianca = 10,

        [Display(Name = "Coordenador Regional Jovem/Adolescente")]
        CoordenadorRegionalJovemAdolecente = 11,

        [Display(Name = "Coordenador Regional Missão")]
        CoordenadorRegionalMissao = 12,

        // Líderes
        [Display(Name = "Líder Diaconato")]
        LiderDiaconato = 13,

        [Display(Name = "Líder Louvor")]
        LiderLouvor = 14,

        [Display(Name = "Líder Homens")]
        LiderHomens = 15,

        [Display(Name = "Líder Mulher")]
        LiderMulher = 16,

        [Display(Name = "Líder Mídia")]
        LiderMidia = 17,

        [Display(Name = "Líder Teatro")]
        LiderTeatro = 18,

        [Display(Name = "Líder Criança")]
        LiderCrianca = 19,

        [Display(Name = "Líder Jovem/Adolescente")]
        LiderJovemAdolecente = 20,

        [Display(Name = "Líder Missão")]
        LiderMissao = 21,

        [Display(Name = "Membro")]
        Membro = 22
    }
}