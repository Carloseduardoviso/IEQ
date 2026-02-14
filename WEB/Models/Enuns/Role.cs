using System.ComponentModel.DataAnnotations;

namespace WEB.Models.Enuns
{
    public enum Role
    {
        // ===== LOCAL =====
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

        [Display(Name = "Casal")]
        Casal = 12,

        [Display(Name = "Diácono")]
        Diacono = 13,

        [Display(Name = "Diaconisa")]
        Diaconisa = 14,

        [Display(Name = "Diretor")]
        Diretor = 15,

        [Display(Name = "Diretora")]
        Diretora = 16,

        [Display(Name = "Líder Local")]
        LiderLocal = 17,

        [Display(Name = "Vice-Líder")]
        ViceLider = 18,

        [Display(Name = "Secretário(a)")]
        Secretario = 19,

        [Display(Name = "Tesoureiro(a)")]
        Tesoureiro = 20,

        [Display(Name = "Pastor(a)")]
        Pastor = 21,

        [Display(Name = "Pastor(a) Auxiliar")]
        PastorAuxiliar = 22,

        // ===== REGIONAL =====
        [Display(Name = "Superintendente Regional")]
        SuperintendenteRegional = 50,

        [Display(Name = "Coordenador Regional de Diaconato")]
        CoordenadorRegionalDiaconato = 51,

        [Display(Name = "Coordenador Regional de Louvor")]
        CoordenadorRegionalLouvor = 52,

        [Display(Name = "Coordenador Regional de Homens")]
        CoordenadorRegionalHomens = 53,

        [Display(Name = "Coordenador Regional de Mulheres")]
        CoordenadorRegionalMulher = 54,

        [Display(Name = "Coordenador Regional de Mídia")]
        CoordenadorRegionalMidia = 55,

        [Display(Name = "Coordenador Regional de Teatro")]
        CoordenadorRegionalTeatro = 56,

        [Display(Name = "Coordenador Regional de Crianças")]
        CoordenadorRegionalCrianca = 57,

        [Display(Name = "Coordenador Regional de Jovens/Adolescentes")]
        CoordenadorRegionalJovemAdolescente = 58,

        [Display(Name = "Coordenador Regional de Missão")]
        CoordenadorRegionalMissao = 59,

        [Display(Name = "Coordenador Regional de Casal")]
        CoordenadorRegionalCasal = 60
    }
}