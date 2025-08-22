namespace WEB.Models.Entities;

public class Diaconato
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
    public bool Ativo { get; set; }
}
