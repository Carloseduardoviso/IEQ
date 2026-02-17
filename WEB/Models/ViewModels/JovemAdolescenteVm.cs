using System.ComponentModel.DataAnnotations;
using WEB.Models.Entities;
using WEB.Models.Enuns;

namespace WEB.Models.ViewModels
{
    public class JovemAdolescenteVm
    {
        public Guid JovemAdolecenteId { get; set; }

        [Display(Name = "Nome Completo")]
        [Required]
        [MaxLength(100)]
        public string? NomeCompleto { get; set; }

        [Display(Name = "Igreja")]
        [Required]
        public Guid IgrejaId { get; set; }
        public Guid? SuperintendenteEstadualId { get; set; }
        public Guid? SuperintendenteRegionalId { get; set; }

        [Display(Name = "Região")]
        [Required]
        public Guid RegiaoId { get; set; }

        [Display(Name = "Pastor")]
        public Guid? PastorId { get; set; }

        [Required]
        public CargoLocal CargoLocal { get; set; }
        public CargoRegional CargoRegional { get; set; }

        [Required]
        [Phone]
        public string? Contato { get; set; }


        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Required]
        [Display(Name = "Data de Ministerio")]
        public DateTime? DataMinisterio { get; set; }
        [Display(Name = "Data de Batismo")]
        public DateTime? DataBatismo { get; set; }

        public int TempoAcumuladoEmMeses { get; set; }

        public DateTime? DataReativacao { get; set; }
        public DateTime? DataInativacao { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public string? Cidade { get; set; }

        public bool Ativo { get; set; } = true;

        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }

        public Igreja? Igreja { get; set; }
        public Regiao? Regiao { get; set; }
        public Pastores? Pastor { get; set; }
        public SuperintendenteEstadual? SuperintendenteEstadual { get; set; }
        public SuperintendenteRegional? SuperintendenteRegional { get; set; }

        // 🔹 TEMPO MINISTÉRIO
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

                if (mesesTotais <= 0) return "-";

                int anos = mesesTotais / 12;
                int mesesRestantes = mesesTotais % 12;

                if (anos > 0 && mesesRestantes > 0)
                    return $"{anos} ano(s) e {mesesRestantes} mês(es)";

                if (anos > 0)
                    return $"{anos} ano(s)";

                return $"{mesesRestantes} mês(es)";
            }
        }
    }
}
