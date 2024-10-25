using ComisionQA;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace comision_api.Validations
{
    public class EmailUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var serviceProvider = validationContext.GetService<IServiceProvider>();
            var dbContext = serviceProvider.GetRequiredService<ComisionQaContext>();

            var email = value.ToString();
            var user = dbContext.Users.SingleOrDefault(u => u.email == email);

            if (user != null)
            {
                return new ValidationResult("El correo electrónico ya está en uso.");
            }

            return ValidationResult.Success;
        }
    }
}
