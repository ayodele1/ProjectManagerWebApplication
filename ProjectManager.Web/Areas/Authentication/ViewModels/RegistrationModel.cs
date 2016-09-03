
using DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectManager.Web.Areas.Authentication.ViewModels
{
    [MetadataType(typeof(RegisterationValidation))]
    public class RegistrationModel
    {
        #region Custom Validation
        public class UniqueUsernameAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var userNameToValidate = value.ToString();

                using (var context = new ProjectManagerContext())
                {
                    var existingUsername = context.Users.AsNoTracking().FirstOrDefault(u => string.Equals(u.UserName, userNameToValidate));
                    if (existingUsername != null)
                        return new ValidationResult("Username already Exists");
                    return ValidationResult.Success;
                }
            }
        }

        public class UniqueEmailAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var emailToValidate = value.ToString();

                using (var context = new ProjectManagerContext())
                {
                    var existingEmail = context.Users.AsNoTracking().FirstOrDefault(u => string.Equals(u.Email, emailToValidate));
                    if (existingEmail != null)
                        return new ValidationResult("Emailaaaaa already Exists");
                    return ValidationResult.Success;
                }
            }
        }
        #endregion

        public RegistrationModel()
        {

        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string confirmPassword { get; set; }

        public int ResponsibilityId { get; set; } //Foreign Key

        class RegisterationValidation
        {
            public int ResponsibilityId { get; set; } //Foreign Key

            [UniqueUsername]
            [Required]
            public string UserName { get; set; }

            [UniqueEmail]
            [Required]
            [EmailAddress(ErrorMessage = "Emailaaaa address is invalid")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password is too short. Must be at least 7 characters long")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords must match")]
            public string confirmPassword { get; set; }
        }
    }
}