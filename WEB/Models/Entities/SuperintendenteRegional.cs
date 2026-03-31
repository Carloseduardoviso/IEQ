using WEB.Models.ViewModels;

namespace WEB.Models.Entities
{
    public class SuperintendenteRegional
    {
        public Guid SuperintendenteRegionalId { get; set; }

        public string Nome { get; set; } = null!;
        public string? FotoUrl { get; set; }

        public bool Ativo { get; set; } = true;

        public ICollection<Regiao> Regioes { get; set; } = new List<Regiao>();
        public ICollection<Diaconato>? Diaconos { get; set; } = new List<Diaconato>();

        public static SuperintendenteRegional Adicionar(MembroVm vm)
        {
            return new SuperintendenteRegional
            {
                SuperintendenteRegionalId = Guid.NewGuid(),
                Nome = vm.NomeCompleto,          
                FotoUrl = vm.FotoUrl,
                Ativo = true,
            };
        }
    }
}