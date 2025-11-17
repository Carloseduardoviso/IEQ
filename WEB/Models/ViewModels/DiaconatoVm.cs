namespace WEB.Models.ViewModels
{
    public class DiaconatoVm
    {
        public Guid DiaconatoId  { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Regiao { get; set; }
        public string? Igreja { get; set; }
        public string? Cargo { get; set; }
        public string? Contato { get; set; }
        public string? NomePastor { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataMinisterio { get; set; }
        public DateTime? DataBatismo { get; set; }
        public bool Ativo { get; set; } = true;
        public IFormFile? Foto { get; set; }
        public string? FotoUrl { get; set; }

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
