using System.ComponentModel.DataAnnotations;

namespace comision_api.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage ="La contraseña tiene que ser mayor de 8 caracteres")]
        public string password { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8)]
        [Compare("password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string password_confirmation { get; set; }
    }
}
