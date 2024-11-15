using comision_api.Validations;
using System.ComponentModel.DataAnnotations;

namespace comision_api.Dto
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        [EmailUnique]
        public string email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string password { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8)]
        [Compare("password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string password_confirmation { get; set; }
        [Required]
        [StringLength(30)]
        public string firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string maternal { get; set; }
        [Required]
        [StringLength(30)]
        public string paternal { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength = 10)]
        public string? phone { get; set; }
        [StringLength(50)]
        public string? address { get; set; }

}
}
