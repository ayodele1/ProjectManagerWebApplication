using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainObjects
{
    public class Project : IModificationHistory
    {
        public Project()
        {
            this.Users = new HashSet<User>();
            this.Owners = new HashSet<User>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [InverseProperty("ProjectsOwned")]
        public ICollection<User> Owners { get; set; }

        [InverseProperty("Projects")]
        public ICollection<User> Users { get; set; }

        public ICollection<UserStory> UserStories { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
