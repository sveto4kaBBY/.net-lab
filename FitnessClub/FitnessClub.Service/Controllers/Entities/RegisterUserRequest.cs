using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FitnessClub.FitnessClub.Service.Controllers.Entities
{
    public class RegisterUserRequest : IValidatableObject
    {
        //про роль добавить
        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string Position { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Проверка логина (только буквы и цифры)
            if (!Regex.IsMatch(Login, @"^[a-zA-Z0-9]+$"))
            {
                errors.Add(new ValidationResult("Login contains invalid symbols. Only alphanumeric characters are allowed."));
            }

            
            if (!string.IsNullOrEmpty(Email) && !new EmailAddressAttribute().IsValid(Email))
            {
                errors.Add(new ValidationResult("Invalid email address format."));
            }

            return errors;
        }
    }
}