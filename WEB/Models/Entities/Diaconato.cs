namespace WEB.Models.Entities;

public class Diaconato
{
    public Guid DiaconatoId { get; set; }
    public string? NomeCompleto { get; set; }
    public string? Regiao { get; set; }
    public string? Igreja { get; set; }
    public string? Cargo { get; set; }
    public string? Contato { get; set; }
    public string? NomePastor { get; set; }
    public string? NomeSuperintendenteRegional { get; set; }
    public string? NomeSuperintendenteEstadual { get; set; }
    public DateTime? DataNascimento { get; set; }
    public DateTime? DataMinisterio { get; set; }
    public DateTime? DataBatismo { get; set; }
    public int TempoAcumuladoEmMeses { get; set; } = 0;
    public DateTime? DataReativacao { get; set; }
    public DateTime? DataInativacao { get; set; }
    public string? Estado { get; set; }
    public string? Cidade { get; set; }
    public bool Ativo { get; set; }
    public string? FotoUrl { get; set; }
    public string? FotoUrlConsagracao { get; set; }
    public string? FotoUrl5Anos { get; set; }
    public string? FotoUrl10Anos { get; set; }
    public string? FotoUrl15Anos { get; set; }
    public string? FotoUrl20Anos { get; set; }
    public string? FotoUrl25Anos { get; set; }
}
