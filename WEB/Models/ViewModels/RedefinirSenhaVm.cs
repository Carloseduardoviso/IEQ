using System.ComponentModel.DataAnnotations;

public class RedefinirSenhaVm
{

    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string NovaSenha { get; set; }

    [Compare("NovaSenha")]
    public string ConfirmarSenha { get; set; }
}