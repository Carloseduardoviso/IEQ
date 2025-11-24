using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class DiaconatoVm
    {
        public Guid DiaconatoId  { get; set; }

        [Display(Name = "Nome Completo")]
        [MaxLength(100, ErrorMessage = "O limite máximo 100 caracter, foi atingido.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? NomeCompleto { get; set; }

        [Display(Name = "Região")]
        [MaxLength(10, ErrorMessage = "O limite máximo 10 numeros, foi atingido.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Regiao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Igreja { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Cargo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Contato { get; set; }

        [Display(Name = "Nome do Pastor")]
        [MaxLength(100, ErrorMessage = "O limite máximo 100 caracter, foi atingido.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? NomePastor { get; set; }
        [Display(Name = "Nome do Pastor")]
        [MaxLength(100, ErrorMessage = "O limite máximo 100 caracter, foi atingido.")]
        public string? NomeSuperintendenteRegional { get; set; }

        [Display(Name = "Nome do Pastor")]
        [MaxLength(100, ErrorMessage = "O limite máximo 100 caracter, foi atingido.")]
        public string? NomeSuperintendenteEstadual { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Inicio do Ministério")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public DateTime? DataMinisterio { get; set; }

        [Display(Name = "Data do Batismo")]
        public DateTime? DataBatismo { get; set; }
        public int TempoAcumuladoEmMeses { get; set; } = 0;
        public DateTime? DataReativacao { get; set; }
        public DateTime? DataInativacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public string? Cidade { get; set; }
        public bool Ativo { get; set; } = true;

        [Display(Name = "Foto de Perfil")]
        public IFormFile? Foto { get; set; }

        [Display(Name = "Consagração")]
        public IFormFile? FotoConsagracao { get; set; }

        [Display(Name = "Condecoração de 5 Anos")]
        public IFormFile? Foto5Anos { get; set; }
        [Display(Name = "Condecoração de 10 Anos")]
        public IFormFile? Foto10Anos { get; set; }
        [Display(Name = "Condecoração de 15 Anos")]
        public IFormFile? Foto15Anos { get; set; }
        [Display(Name = "Condecoração de 20 Anos")]
        public IFormFile? Foto20Anos { get; set; }
        [Display(Name = "Condecoração de 25 Anos")]
        public IFormFile? Foto25Anos { get; set; }
        public string? FotoUrl { get; set; }
        public string? FotoUrlConsagracao { get; set; }
        public string? FotoUrl5Anos { get; set; }
        public string? FotoUrl10Anos { get; set; }
        public string? FotoUrl15Anos { get; set; }
        public string? FotoUrl20Anos { get; set; }
        public string? FotoUrl25Anos { get; set; }
        public string TempoMinisterio
        {
            get
            {
                int mesesTotais = TempoAcumuladoEmMeses;

                if (Ativo && DataReativacao != null)
                {
                    var inicio = DataReativacao.Value;
                    var fim = DateTime.Today;

                    int meses = ((fim.Year - inicio.Year) * 12) + fim.Month - inicio.Month;

                    if (fim.Day < inicio.Day)
                        meses--;

                    mesesTotais += Math.Max(0, meses);
                }

                if (mesesTotais <= 0)
                    return "-";

                int anos = mesesTotais / 12;
                int mesesRestantes = mesesTotais % 12;

                if (anos > 0 && mesesRestantes > 0)
                    return $"{anos} ano(s) e {mesesRestantes} mês(es)";
                else if (anos > 0)
                    return $"{anos} ano(s)";
                else
                    return $"{mesesRestantes} mês(es)";
            }
        }
    }
}
