
using System.ComponentModel.DataAnnotations;
namespace ProjectManager.Web.Areas.Authentication.ViewModels
{
    [MetadataType(typeof(LoginValidation))]
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        class LoginValidation
        {
            [Required]
            [Display(Name = "Username or Email Address")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}