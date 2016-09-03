using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainObjects
{
    public class User : IModificationHistory
    {

        public User()
        {
            this.Projects = new HashSet<Project>();
            this.ProjectsOwned = new HashSet<Project>();
        }
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

        [InverseProperty("Owners")]
        public ICollection<Project> ProjectsOwned { get; set; }

        [InverseProperty("Users")]
        public ICollection<Project> Projects { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
