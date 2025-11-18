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

        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Inicio do Ministério")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public DateTime? DataMinisterio { get; set; }

        [Display(Name = "Data do Batismo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
        public DateTime? DataBatismo { get; set; }
        public bool Ativo { get; set; } = true;

        [Display(Name = "Foto de Perfil")]
        [Required(ErrorMessage = "O campo {0} é obrigatório !")]
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
                if (DataMinisterio == null)
                    return "-";

                var inicio = DataMinisterio.Value;
                var hoje = DateTime.Today;

                var anos = hoje.Year - inicio.Year;
                var meses = hoje.Month - inicio.Month;

                if (hoje.Day < inicio.Day)
                    meses--;

                if (meses < 0)
                {
                    anos--;
                    meses += 12;
                }

                if (anos > 0 && meses > 0)
                    return $"{anos} ano(s) e {meses} mês(es)";
                else if (anos > 0)
                    return $"{anos} ano(s)";
                else
                    return $"{meses} mês(es)";
            }
        }
    }
}
