using System.ComponentModel.DataAnnotations;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;

namespace WEB.Models.Entities
{
    public class Pastores
    {
        public Guid PastorId { get; set; }
        public Guid IgrejaId { get; set; }
        public Guid? MembroId { get; set; }

        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? FotoUrl { get; set; }
        public CargoLocal CargoLocal { get; set; }
        public CargoRegional? CargoRegional { get; set; }
        public bool Ativo { get; set; } = true;
        public Igreja Igreja { get; set; } = null!;
        public Membro? Membro { get; set; }

        public static Pastores Adicionar(MembroVm vm)
        {
            return new Pastores
            {
                PastorId = Guid.NewGuid(),
                Nome = vm.NomeCompleto,
                IgrejaId = vm.IgrejaId,
                Telefone = vm.Contato,
                FotoUrl = vm.FotoUrl,
                Ativo = true,
                CargoLocal = vm.CargoLocal,
                CargoRegional = vm.CargoRegional
            };
        }
    }
}