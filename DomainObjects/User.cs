using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainObjects
{
    public class User : IModificationHistory
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [ForeignKey("ResponsibilityId")]
        public UserResponsibility Responsibility { get; set; }

        public int ResponsibilityId { get; set; } //Foreign Key

        public char Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
