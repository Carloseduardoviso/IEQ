namespace WEB.Models.Entities
{
    public class Regiao
    {
        public Guid RegiaoId { get; set; }
        public Guid? SuperintendenteRegionalId { get; set; }

        public string Nome { get; set; } = null!;
        public Guid? SuperintendenteEstadualId { get; set; }

        public SuperintendenteRegional? SuperintendenteRegional { get; set; }

        public SuperintendenteEstadual? SuperintendenteEstadual { get; set; }

        public ICollection<Igreja> Igrejas { get; set; } = new List<Igreja>();
        public ICollection<Diaconato> Diaconos { get; set; } = new List<Diaconato>();
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Crianca> Criancas { get; set; } = new List<Crianca>();
        public ICollection<Homens> Homens { get; set; } = new List<Homens>();
        public ICollection<JovemAdolescente> JovemAdolecentes { get; set; } = new List<JovemAdolescente>();
        public ICollection<Louvor> Louvors { get; set; } = new List<Louvor>();
        public ICollection<Midia> Midias { get; set; } = new List<Midia>();
        public ICollection<Mulheres> Mulheres { get; set; } = new List<Mulheres>();
        public ICollection<Teatro> Teatros { get; set; } = new List<Teatro>();
        public ICollection<Danca> Dancas { get; set; } = new List<Danca>();
        public ICollection<Casal> Casals { get; set; } = new List<Casal>();
        public ICollection<Membro> Membros { get; set; } = new List<Membro>();
    }
}