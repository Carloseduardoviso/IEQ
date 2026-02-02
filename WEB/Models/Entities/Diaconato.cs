namespace WEB.Models.Entities
{
    public class Diaconato
    {
        public Guid DiaconatoId { get; set; }

        public string NomeCompleto { get; set; } = null!;

        // 🔹 RELACIONAMENTOS
        public Guid IgrejaId { get; set; }
        public Igreja Igreja { get; set; } = null!;

        public Guid RegiaoId { get; set; }
        public Regiao Regiao { get; set; } = null!;

        public Guid? PastorId { get; set; }
        public Pastores? Pastor { get; set; }

        public string Cargo { get; set; } = null!;
        public string Contato { get; set; } = null!;

        public DateTime? DataNascimento { get; set; }
        public DateTime DataMinisterio { get; set; }
        public DateTime? DataBatismo { get; set; }

        public int TempoAcumuladoEmMeses { get; set; } = 0;

        public DateTime? DataReativacao { get; set; }
        public DateTime? DataInativacao { get; set; }

        public string Estado { get; set; } = null!;
        public string Cidade { get; set; } = null!;

        public bool Ativo { get; set; } = true;

        // 🔹 FOTOS
        public string? FotoUrl { get; set; }
        public string? FotoUrlConsagracao { get; set; }
        public string? FotoUrl5Anos { get; set; }
        public string? FotoUrl10Anos { get; set; }
        public string? FotoUrl15Anos { get; set; }
        public string? FotoUrl20Anos { get; set; }
        public string? FotoUrl25Anos { get; set; }
    }
}
