using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class EsqueciMinhaSenhaVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
