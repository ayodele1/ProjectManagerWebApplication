using System.Collections.Generic;
using System.Linq;

namespace DomainObjects
{
    public class UserResponsibilityRepository
    {
        public ICollection<UserResponsibility> GetAll()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.UserResponsibilites.AsNoTracking().ToList();
            }
        }
    }
}
