
using System.ComponentModel.DataAnnotations;
namespace DomainObjects
{
    public class UserStoryTask : IModificationHistory
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public int UserStoryId { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
