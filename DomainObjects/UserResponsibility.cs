
using System.ComponentModel.DataAnnotations;
namespace DomainObjects
{
    public class UserResponsibility : IModificationHistory
    {
        public int Id { get; set; }
        [Required]
        public string Responsibility { get; set; }

        public System.DateTime DateModified { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
