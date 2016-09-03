using System.Collections.Generic;
using System.Linq;

namespace DomainObjects
{
    public class UserResponsibilityRepository
    {
        private ProjectManagerContext context;

        public ICollection<UserResponsibility> GetAll()
        {
            using (context = new ProjectManagerContext())
            {
                return context.UserResponsibilites.AsNoTracking().ToList();
            }
        }
    }
}
