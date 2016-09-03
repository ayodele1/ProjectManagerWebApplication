
using System.ComponentModel.DataAnnotations;
namespace DomainObjects
{
    public class UserResponsibility
    {
        public int Id { get; set; }
        [Required]
        public string Responsibility { get; set; }
    }
}
