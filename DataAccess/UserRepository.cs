
using System.Collections.Generic;
using System.Linq;
namespace DomainObjects
{
    public class UserRepository
    {
        public User GetUserById(int userId)
        {
            using (var context = new ProjectManagerContext())
            {
                var user = context.Users.Find(userId);
                return user;
            }
        }

        public ICollection<User> GetAllUsers()
        {
            using (var context = new ProjectManagerContext())
            {
                var users = context.Users.AsNoTracking().ToList();
                return users;
            }
        }


    }
}
