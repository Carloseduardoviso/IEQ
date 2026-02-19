namespace WEB.Models.Entities
{
    public class Igreja
    {
        public Guid IgrejaId { get; set; }
        public Guid RegiaoId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Codigo { get; set; }
        public string? FotoUrl { get; set; }
        public bool Ativo { get; set; } = true;

        public Regiao Regiao { get; set; } = null!;
        public ICollection<Diaconato> Diaconos { get; set; } = new List<Diaconato>();
        public ICollection<Pastores> Pastores { get; set; } = new List<Pastores>();
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