using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class LoginVm
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }
    }
}