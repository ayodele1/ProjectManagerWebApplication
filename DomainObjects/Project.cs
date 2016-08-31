using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainObjects
{
    public class Project : IModificationHistory
    {
        public Project()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<UserStory> UserStories { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
