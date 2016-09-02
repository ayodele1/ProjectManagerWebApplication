using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class UserStory : IModificationHistory
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; } //Foreign Key

        public ICollection<UserStoryTask> Tasks { get; set; }

        public ICollection<string> Comments { get; set; }

        public double TimeEstimated { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
