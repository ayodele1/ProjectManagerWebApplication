using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace DomainObjects
{
    [MetadataType(typeof(UserValidation))]
    public class User : IModificationHistory
    {
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
        public User()
        {
            this.Projects = new HashSet<Project>();
            this.ProjectsOwned = new HashSet<Project>();
        }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string confirmPassword { get; set; }

        [ForeignKey("ResponsibilityId")]
        public UserResponsibility Responsibility { get; set; }

        public int ResponsibilityId { get; set; } //Foreign Key

        public string Role { get; set; }

        [InverseProperty("Owners")]
        public ICollection<Project> ProjectsOwned { get; set; }

        [InverseProperty("Users")]
        public ICollection<Project> Projects { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }


        /// <summary>
        /// Uses BCrypt to Hash the password before saving in the Database.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public void SetPasswordHash(string password)
        {
            this.Password = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">User Input</param>
        /// <param name="passWordHash">Saved Password</param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string passWordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passWordHash);
        }

        class UserValidation
        {
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

            [NotMapped]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords must match")]
            public string confirmPassword { get; set; }
        }

    }
}
